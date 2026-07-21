using GodaddyWrapper.Base;
using GodaddyWrapper.Helper;
using GodaddyWrapper.Requests;
using GodaddyWrapper.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GodaddyWrapper
{
    public partial class GoDaddyClient
    {
        // ----- Discovery -----

        /// <summary>
        /// Check availability and indicative pricing for a single domain (Domains v3).
        /// </summary>
        public async Task<DomainAvailableV3Response> CheckDomainAvailableV3(DomainAvailableV3 request)
        {
            CheckRequestValid(request);
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"v3/domains/check-availability{QueryStringBuilder.RequestObjectToQueryString(request)}");
            var response = await SendRequestAsync(httpRequest);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainAvailableV3Response>(JsonSettings);
        }

        /// <summary>
        /// Suggest available domains for a query (Domains v3).
        /// </summary>
        public async Task<DomainSuggestionsV3Response> SuggestDomainsV3(DomainSuggestV3 request)
        {
            CheckRequestValid(request);
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"v3/domains/suggestions{QueryStringBuilder.RequestObjectToQueryString(request)}");
            var response = await SendRequestAsync(httpRequest);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainSuggestionsV3Response>(JsonSettings);
        }

        // ----- Quote -> Register -----

        /// <summary>
        /// Obtain a locked price and a <c>quoteToken</c> for registering a domain (Domains v3).
        /// The returned token is valid for approximately 10 minutes.
        /// </summary>
        public async Task<RegistrationQuoteResponse> CreateRegistrationQuote(RegistrationQuoteCreate request)
        {
            CheckRequestValid(request);
            using var httpRequest = CreateJsonRequest(HttpMethod.Post, "v3/domains/registration-quotes", request);
            var response = await SendRequestAsync(httpRequest);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<RegistrationQuoteResponse>(JsonSettings);
        }

        /// <summary>
        /// Execute a domain registration using a <c>quoteToken</c> (Domains v3). This is an asynchronous
        /// operation; poll <see cref="GetRegistrationStatus"/> or <see cref="WaitForDomainOperation"/>.
        /// </summary>
        /// <param name="request">The registration body (domain, period, quoteToken, consent).</param>
        /// <param name="idempotencyKey">
        /// Optional idempotency key. When omitted a fresh key is generated so retries of this single call
        /// are safe; supply a stable key to make retries across process boundaries idempotent.
        /// </param>
        public async Task<DomainRegistrationResponse> RegisterDomainV3(DomainRegistrationCreate request, string idempotencyKey = null)
        {
            CheckRequestValid(request);
            using var httpRequest = CreateJsonRequest(HttpMethod.Post, "v3/domains/registrations", request, idempotencyKey);
            var response = await SendRequestAsync(httpRequest);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainRegistrationResponse>(JsonSettings);
        }

        /// <summary>
        /// Convenience helper that quotes a domain and then registers it, agreeing to the agreements the
        /// quote requires (Domains v3).
        /// </summary>
        /// <param name="quote">The quote request (domain, period, optional profile).</param>
        /// <param name="agreementTypes">
        /// Agreement types to consent to. When null, the agreement types the quote reports as required are used.
        /// </param>
        /// <param name="idempotencyKey">Optional idempotency key for the registration call.</param>
        public async Task<DomainRegistrationResponse> RegisterDomainWithQuoteAsync(RegistrationQuoteCreate quote, IEnumerable<string> agreementTypes = null, string idempotencyKey = null)
        {
            var quoteResult = await CreateRegistrationQuote(quote);
            if (!quoteResult.Available || string.IsNullOrEmpty(quoteResult.QuoteToken))
                throw new InvalidOperationException($"Domain '{quote.Domain}' is not available for registration.");

            var types = new List<string>();
            if (agreementTypes != null)
                types.AddRange(agreementTypes);
            else if (quoteResult.RequiredAgreements != null)
                foreach (var agreement in quoteResult.RequiredAgreements)
                    types.Add(agreement.AgreementType);

            var registration = new DomainRegistrationCreate
            {
                Domain = quote.Domain,
                Period = quote.Period,
                QuoteToken = quoteResult.QuoteToken,
                Consent = new RegistrationConsent
                {
                    AgreementTypes = types,
                    AgreedAt = DateTime.UtcNow
                }
            };
            return await RegisterDomainV3(registration, idempotencyKey);
        }

        /// <summary>
        /// Retrieve the status of a registration (Domains v3).
        /// </summary>
        public async Task<DomainRegistrationResponse> GetRegistrationStatus(string registrationId)
        {
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"v3/domains/registrations/{registrationId}");
            var response = await SendRequestAsync(httpRequest);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainRegistrationResponse>(JsonSettings);
        }

        // ----- Domain read / nameservers -----

        /// <summary>
        /// Retrieve details for a registered domain (Domains v3).
        /// </summary>
        public async Task<DomainDetailV3Response> GetDomainV3(string domain)
        {
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"v3/domains/domain-names/{domain}");
            var response = await SendRequestAsync(httpRequest);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainDetailV3Response>(JsonSettings);
        }

        /// <summary>
        /// Replace the nameservers for a domain (Domains v3). This is an asynchronous operation;
        /// poll the returned operation with <see cref="GetDomainOperation"/> or <see cref="WaitForDomainOperation"/>.
        /// </summary>
        /// <param name="domain">The domain to update.</param>
        /// <param name="nameServers">The full set of nameservers (2-13 hostnames).</param>
        /// <param name="idempotencyKey">Optional idempotency key (auto-generated when omitted).</param>
        public async Task<DomainOperationResponse> UpdateNameServersV3(string domain, List<string> nameServers, string idempotencyKey = null)
        {
            using var httpRequest = CreateJsonRequest(HttpMethod.Put, $"v3/domains/domain-names/{domain}/nameservers", nameServers, idempotencyKey);
            var response = await SendRequestAsync(httpRequest);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainOperationResponse>(JsonSettings);
        }

        // ----- DNS records (zone-based) -----

        /// <summary>
        /// List DNS records for a zone (Domains v3).
        /// </summary>
        public async Task<DNSRecordPageResponse> RetrieveDNSRecordsV3(string zone, DNSRecordRetrieveV3 request = null)
        {
            string queryString = request == null ? string.Empty : QueryStringBuilder.RequestObjectToQueryString(request);
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"v3/domains/zones/{zone}/dns-records{queryString}");
            var response = await SendRequestAsync(httpRequest);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DNSRecordPageResponse>(JsonSettings);
        }

        /// <summary>
        /// Create DNS records in a zone (Domains v3, synchronous).
        /// </summary>
        public async Task<List<DNSRecordResponseV3>> AddDNSRecordsV3(string zone, List<DNSRecordV3> records)
        {
            CheckRequestValid(records);
            using var httpRequest = CreateJsonRequest(HttpMethod.Post, $"v3/domains/zones/{zone}/dns-records", records);
            var response = await SendRequestAsync(httpRequest);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<List<DNSRecordResponseV3>>(JsonSettings);
        }

        /// <summary>
        /// Replace all DNS records in a zone (Domains v3, synchronous).
        /// </summary>
        public async Task<bool> ReplaceDNSRecordsV3(string zone, List<DNSRecordV3> records)
        {
            CheckRequestValid(records);
            using var httpRequest = CreateJsonRequest(HttpMethod.Put, $"v3/domains/zones/{zone}/dns-records", records);
            var response = await SendRequestAsync(httpRequest);
            await CheckResponseMessageIsValid(response);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Delete a DNS record from a zone by its record identifier (Domains v3, synchronous).
        /// </summary>
        public async Task<bool> DeleteDNSRecordV3(string zone, string recordId)
        {
            using var httpRequest = new HttpRequestMessage(HttpMethod.Delete, $"v3/domains/zones/{zone}/dns-records/{recordId}");
            var response = await SendRequestAsync(httpRequest);
            await CheckResponseMessageIsValid(response);
            return response.IsSuccessStatusCode;
        }

        // ----- Async operations -----

        /// <summary>
        /// Retrieve the current state of an asynchronous Domains v3 operation.
        /// </summary>
        public async Task<DomainOperationResponse> GetDomainOperation(string operationId)
        {
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"v3/domains/operations/{operationId}");
            var response = await SendRequestAsync(httpRequest);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainOperationResponse>(JsonSettings);
        }

        /// <summary>
        /// Poll an asynchronous Domains v3 operation until it reaches a terminal state.
        /// </summary>
        /// <param name="operationId">The operation to poll.</param>
        /// <param name="pollInterval">Delay between polls (default 2 seconds).</param>
        /// <param name="timeout">Maximum time to wait (default 5 minutes).</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The operation once <c>COMPLETED</c> (or <c>CONFIRMED</c>).</returns>
        /// <exception cref="GodaddyException">Thrown when the operation ends in <c>FAILED</c>.</exception>
        /// <exception cref="TimeoutException">Thrown when the timeout elapses before completion.</exception>
        public async Task<DomainOperationResponse> WaitForDomainOperation(string operationId, TimeSpan? pollInterval = null, TimeSpan? timeout = null, CancellationToken cancellationToken = default)
        {
            var interval = pollInterval ?? TimeSpan.FromSeconds(2);
            var limit = timeout ?? TimeSpan.FromMinutes(5);
            var start = DateTime.UtcNow;

            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var operation = await GetDomainOperation(operationId);

                if (string.Equals(operation.Status, "FAILED", StringComparison.OrdinalIgnoreCase))
                {
                    var message = operation.Error?.Message ?? "The GoDaddy operation failed.";
                    throw new GodaddyException(System.Net.HttpStatusCode.OK, new ErrorResponse { Code = operation.Error?.Name, Message = message }, message);
                }

                if (string.Equals(operation.Status, "COMPLETED", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(operation.Status, "CONFIRMED", StringComparison.OrdinalIgnoreCase))
                {
                    return operation;
                }

                if (DateTime.UtcNow - start > limit)
                    throw new TimeoutException($"Timed out waiting for GoDaddy operation '{operationId}' to complete.");

                await Task.Delay(interval, cancellationToken);
            }
        }
    }
}
