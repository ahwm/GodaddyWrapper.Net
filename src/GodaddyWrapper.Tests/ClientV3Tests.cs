#if NETCORE
using GodaddyWrapper.Base;
using GodaddyWrapper.Requests;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GodaddyWrapper.Tests
{
    /// <summary>
    /// Behavioural tests for the v5 client using a mock HTTP handler (no network calls).
    /// </summary>
    public class ClientV3Tests
    {
        private sealed class MockHttpMessageHandler : DelegatingHandler
        {
            private readonly Func<HttpRequestMessage, string, HttpResponseMessage> _responder;

            public List<HttpRequestMessage> Requests { get; } = new List<HttpRequestMessage>();
            public List<string> RequestBodies { get; } = new List<string>();

            public MockHttpMessageHandler(Func<HttpRequestMessage, string, HttpResponseMessage> responder)
            {
                _responder = responder;
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                string body = request.Content == null ? null : await request.Content.ReadAsStringAsync();
                Requests.Add(request);
                RequestBodies.Add(body);
                return _responder(request, body);
            }
        }

        private static HttpResponseMessage Json(HttpStatusCode status, string json)
            => new HttpResponseMessage(status) { Content = new StringContent(json, Encoding.UTF8, "application/json") };

        private static (GoDaddyClient client, MockHttpMessageHandler handler) CreateClient(
            Func<HttpRequestMessage, string, HttpResponseMessage> responder, string pat = "test-pat")
        {
            var mock = new MockHttpMessageHandler(responder);
            var bearer = new BearerTokenHandler(Options.Create(new GoDaddyClientOptions { PersonalAccessToken = pat }))
            {
                InnerHandler = mock
            };
            var http = new HttpClient(bearer) { BaseAddress = new Uri("https://api.godaddy.com/") };
            return (new GoDaddyClient(http), mock);
        }

        [Fact]
        public async Task CheckDomainAvailableV3_SendsBearerToken_AndV3Url()
        {
            var (client, handler) = CreateClient((req, body) =>
                Json(HttpStatusCode.OK, "{\"domain\":\"example.com\",\"available\":true,\"definitive\":true}"));

            var result = await client.CheckDomainAvailableV3(new DomainAvailableV3 { Domain = "example.com" });

            result.Available.ShouldBeTrue();
            var request = handler.Requests.Single();
            request.Method.ShouldBe(HttpMethod.Get);
            request.RequestUri.ToString().ShouldBe("https://api.godaddy.com/v3/domains/check-availability?domain=example.com");
            request.Headers.Authorization.Scheme.ShouldBe("Bearer");
            request.Headers.Authorization.Parameter.ShouldBe("test-pat");
        }

        [Fact]
        public async Task RetrieveTldSummary_UsesV1Prefix()
        {
            var (client, handler) = CreateClient((req, body) => Json(HttpStatusCode.OK, "[]"));

            await client.RetrieveTldSummary();

            handler.Requests.Single().RequestUri.ToString().ShouldBe("https://api.godaddy.com/v1/domains/tlds");
        }

        [Fact]
        public async Task RegisterDomainWithQuote_PostsQuoteTokenAndConsent()
        {
            var (client, handler) = CreateClient((req, body) =>
            {
                if (req.RequestUri.AbsolutePath.EndsWith("/registration-quotes"))
                    return Json(HttpStatusCode.OK,
                        "{\"domain\":\"example.com\",\"available\":true,\"quoteToken\":\"tok123\",\"requiredAgreements\":[{\"agreementType\":\"DNRA\"}]}");
                return Json(HttpStatusCode.Accepted,
                    "{\"registrationId\":\"r1\",\"status\":\"PENDING\",\"operationId\":\"op1\"}");
            });

            var result = await client.RegisterDomainWithQuoteAsync(new RegistrationQuoteCreate { Domain = "example.com", Period = 1 });

            result.RegistrationId.ShouldBe("r1");
            handler.Requests.Count.ShouldBe(2);

            var registerBody = handler.RequestBodies[1];
            registerBody.ShouldContain("tok123");
            registerBody.ShouldContain("DNRA");
            registerBody.ShouldContain("agreedAt");
        }

        [Fact]
        public async Task RegisterDomainV3_AutoGeneratesIdempotencyKey_WhenOmitted()
        {
            var (client, handler) = CreateClient((req, body) =>
                Json(HttpStatusCode.Accepted, "{\"registrationId\":\"r1\",\"status\":\"PENDING\"}"));

            await client.RegisterDomainV3(new DomainRegistrationCreate
            {
                Domain = "example.com",
                QuoteToken = "tok",
                Consent = new RegistrationConsent { AgreementTypes = new List<string> { "DNRA" }, AgreedAt = DateTime.UtcNow }
            });

            var key = handler.Requests.Single().Headers.GetValues("Idempotency-Key").Single();
            key.ShouldNotBeNullOrWhiteSpace();
        }

        [Fact]
        public async Task RegisterDomainV3_PassesThroughCallerIdempotencyKey()
        {
            var (client, handler) = CreateClient((req, body) =>
                Json(HttpStatusCode.Accepted, "{\"registrationId\":\"r1\",\"status\":\"PENDING\"}"));

            await client.RegisterDomainV3(new DomainRegistrationCreate
            {
                Domain = "example.com",
                QuoteToken = "tok",
                Consent = new RegistrationConsent { AgreementTypes = new List<string> { "DNRA" }, AgreedAt = DateTime.UtcNow }
            }, idempotencyKey: "my-key");

            handler.Requests.Single().Headers.GetValues("Idempotency-Key").Single().ShouldBe("my-key");
        }

        [Fact]
        public async Task WaitForDomainOperation_ReturnsWhenCompleted()
        {
            var statuses = new Queue<string>(new[] { "EXECUTING", "COMPLETED" });
            var (client, _) = CreateClient((req, body) =>
                Json(HttpStatusCode.OK, $"{{\"operationId\":\"op1\",\"status\":\"{statuses.Dequeue()}\"}}"));

            var result = await client.WaitForDomainOperation("op1", pollInterval: TimeSpan.FromMilliseconds(1));

            result.Status.ShouldBe("COMPLETED");
        }

        [Fact]
        public async Task WaitForDomainOperation_ThrowsWhenFailed()
        {
            var (client, _) = CreateClient((req, body) =>
                Json(HttpStatusCode.OK, "{\"operationId\":\"op1\",\"status\":\"FAILED\",\"error\":{\"message\":\"boom\"}}"));

            var ex = await Should.ThrowAsync<GodaddyException>(
                () => client.WaitForDomainOperation("op1", pollInterval: TimeSpan.FromMilliseconds(1)));
            ex.Message.ShouldContain("boom");
        }

        [Fact]
        public async Task BulkCheckDomainAvailable_203_TakesMixedBranch()
        {
            var (client, handler) = CreateClient((req, body) =>
                Json((HttpStatusCode)203, "{\"domains\":[{\"domain\":\"a.com\",\"available\":true}]}"));

            var result = await client.BulkCheckDomainAvailable(new DomainAvailableBulk
            {
                Domains = new List<string> { "a.com" }
            });

            result.IsFullySuccessed.ShouldBeFalse();
            result.BulkMixedDomain.ShouldNotBeNull();
            handler.Requests.Single().RequestUri.ToString().ShouldStartWith("https://api.godaddy.com/v1/domains/available");
        }

        [Fact]
        public void AddGoDaddy_ResolvesIGoDaddyClient()
        {
            var services = new ServiceCollection();
            services.AddGoDaddy("dummy-pat");
            using var provider = services.BuildServiceProvider();

            provider.GetService<IGoDaddyClient>().ShouldNotBeNull();
        }
    }
}
#endif
