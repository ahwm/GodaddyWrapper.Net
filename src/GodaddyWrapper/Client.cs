using GodaddyWrapper.Responses;
using GodaddyWrapper.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using GodaddyWrapper.Helper;
using GodaddyWrapper.Base;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using GodaddyWrapper.Serialization;

namespace GodaddyWrapper
{
    public partial class GoDaddyClient : IGoDaddyClient
    {
        private const string ProductionEndpoint = "https://api.godaddy.com/";

        private readonly HttpClient httpClient;
        private readonly static JsonSerializerOptions JsonSettings = JsonContext.Default.Options;

        /// <summary>
        /// Primary constructor used by the typed <c>HttpClient</c> registered through
        /// <see cref="ServicesExtension.AddGoDaddy(Microsoft.Extensions.DependencyInjection.IServiceCollection, string)"/>.
        /// The base address and Bearer authentication are supplied by the HttpClient factory and
        /// <see cref="BearerTokenHandler"/>.
        /// </summary>
        /// <param name="client">The configured HttpClient.</param>
        public GoDaddyClient(HttpClient client)
        {
            httpClient = client;
        }

        /// <summary>
        /// Convenience constructor for non-DI usage. Creates and owns an <c>HttpClient</c> pointed at the
        /// GoDaddy production endpoint and authenticated with the supplied Personal Access Token.
        /// </summary>
        /// <param name="options">Client options containing the Personal Access Token.</param>
        public GoDaddyClient(GoDaddyClientOptions options)
        {
            if (options == null || string.IsNullOrWhiteSpace(options.PersonalAccessToken))
                throw new ArgumentException("A GoDaddy Personal Access Token is required.", nameof(options));

            httpClient = new HttpClient
            {
                BaseAddress = new Uri(ProductionEndpoint)
            };
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", options.PersonalAccessToken);
        }

        /// <summary>
        /// Convenience constructor for non-DI usage taking a Personal Access Token directly.
        /// </summary>
        /// <param name="personalAccessToken">The GoDaddy Personal Access Token.</param>
        public GoDaddyClient(string personalAccessToken)
            : this(new GoDaddyClientOptions { PersonalAccessToken = personalAccessToken })
        {
        }

        private static void TryAddHeader(HttpRequestMessage request, string headerName, string headerValue)
        {
            if (!string.IsNullOrWhiteSpace(headerValue))
                request.Headers.TryAddWithoutValidation(headerName, headerValue);
        }

        private static HttpRequestMessage CreateJsonRequest<TRequest>(HttpMethod method, string requestUri, TRequest payload)
        {
            return new HttpRequestMessage(method, requestUri)
            {
                Content = new StringContent(JsonSerializer.Serialize(payload, JsonSettings), Encoding.UTF8, "application/json")
            };
        }

        /// <summary>
        /// Builds a JSON request carrying an <c>Idempotency-Key</c> header, used by v3 write operations.
        /// When <paramref name="idempotencyKey"/> is null or empty a fresh key is generated so retries of a
        /// single call are safe; callers needing cross-retry idempotency should supply their own stable key.
        /// </summary>
        private static HttpRequestMessage CreateJsonRequest<TRequest>(HttpMethod method, string requestUri, TRequest payload, string idempotencyKey)
        {
            var request = CreateJsonRequest(method, requestUri, payload);
            var key = string.IsNullOrWhiteSpace(idempotencyKey) ? Guid.NewGuid().ToString("N") : idempotencyKey;
            request.Headers.TryAddWithoutValidation("Idempotency-Key", key);
            return request;
        }

        private async Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage request, string xShopperId = null, string xMarketId = null, string xPrivateLabelId = null)
        {
            TryAddHeader(request, "X-Shopper-Id", xShopperId);
            TryAddHeader(request, "X-Market-Id", xMarketId);
            TryAddHeader(request, "X-Private-Label-Id", xPrivateLabelId);
            return await httpClient.SendAsync(request);
        }

        private static async Task CheckResponseMessageIsValid(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return;
            throw new GodaddyException(response.StatusCode, await response.Content.ReadAsAsync<ErrorResponse>(JsonSettings), "");
        }

        private static void CheckRequestValid(object Model)
        {
            var results = new List<ValidationResult>();
            if (!ModelValidator.IsValid(Model, out results))
                throw new GodaddyValidationException(results);
        }
    }

    /// <summary>
    /// Configuration for <see cref="GoDaddyClient"/>. Authentication uses a GoDaddy
    /// Personal Access Token (PAT) sent as an <c>Authorization: Bearer</c> header.
    /// </summary>
    public sealed class GoDaddyClientOptions
    {
        /// <summary>
        /// The GoDaddy Personal Access Token. Required.
        /// </summary>
        public string PersonalAccessToken { get; set; }
    }
}