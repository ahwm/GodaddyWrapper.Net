using GodaddyWrapper.Helper;
using GodaddyWrapper.Requests;
using GodaddyWrapper.Responses;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace GodaddyWrapper
{
    public partial class GoDaddyClient
    {
        /// <summary>
        /// Determine whether or not the specified domains are available for purchase (v1 bulk).
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DomainAvailableBulkResultResponse> BulkCheckDomainAvailable(Requests.DomainAvailableBulk request)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsJsonAsync($"v1/domains/available?checkType={request.CheckType}", request.Domains, JsonSettings);
            await CheckResponseMessageIsValid(response);
            if ((int)response.StatusCode == 203)
                return new DomainAvailableBulkResultResponse
                {
                    IsFullySuccessed = false,
                    BulkMixedDomain = await response.Content.ReadAsAsync<DomainAvailableBulkMixedResponse>(JsonSettings)
                };
            else
                return new DomainAvailableBulkResultResponse
                {
                    IsFullySuccessed = true,
                    BulkDomain = await response.Content.ReadAsAsync<Responses.DomainAvailableBulkResponse>(JsonSettings)
                };
        }

        /// <summary>
        /// Cancel a purchased domain
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XShopperId"></param>
        /// <returns></returns>
        public async Task<bool> CancelDomain(DomainDelete request, string XShopperId = null)
        {
            CheckRequestValid(request);
            using var httpRequest = new HttpRequestMessage(HttpMethod.Delete, $"v1/domains/{request.Domain}");
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId);
            await CheckResponseMessageIsValid(response);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Submit a privacy cancellation request for the given domain
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XShopperId"></param>
        /// <returns></returns>
        public async Task<bool> CancelPrivacy(PrivacyDelete request, string XShopperId = null)
        {
            CheckRequestValid(request);
            using var httpRequest = new HttpRequestMessage(HttpMethod.Delete, $"v1/domains/{request.Domain}/privacy");
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId);
            await CheckResponseMessageIsValid(response);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Purchase privacy for a specified domain
        /// </summary>
        /// <param name="request"></param>
        /// <param name="domain"></param>
        /// <param name="XShopperId"></param>
        /// <returns></returns>
        public async Task<DomainPurchaseResponse> PurchasePrivacy(PrivacyPurchase request, string domain, string XShopperId = null)
        {
            CheckRequestValid(request);
            using var httpRequest = CreateJsonRequest(HttpMethod.Post, $"v1/domains/{domain}/privacy/purchase", request);
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainPurchaseResponse>(JsonSettings);
        }

        /// <summary>
        /// Retrieve the schema to be submitted when registering a Domain for the specified TLD
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<JsonPropertyResponse> RetrieveDomainPurchaseSchema(DomainPurchaseSchema request)
        {
            CheckRequestValid(request);
            var response = await httpClient.GetAsync($"v1/domains/purchase/schema/{request.Tld}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<JsonPropertyResponse>(JsonSettings);
        }

        /// <summary>
        /// Renew the specified Domain
        /// </summary>
        /// <param name="request"></param>
        /// <param name="domain"></param>
        /// <param name="XShopperId"></param>
        /// <returns></returns>
        public async Task<DomainPurchaseResponse> RenewDomain(DomainRenew request, string domain, string XShopperId = null)
        {
            CheckRequestValid(request);
            using var httpRequest = CreateJsonRequest(HttpMethod.Post, $"v1/domains/{domain}/renew", request);
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainPurchaseResponse>(JsonSettings);
        }

        /// <summary>
        /// Retrieve the legal agreement(s) required to purchase the specified TLD and add-ons
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XMarketId"></param>
        /// <returns></returns>
        public async Task<List<LegalAgreementResponse>> RetrieveDomainAgreements(DomainAgreements request, string XMarketId)
        {
            CheckRequestValid(request);
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"v1/domains/agreements{QueryStringBuilder.RequestObjectToQueryString(request)}");
            var response = await SendRequestAsync(httpRequest, xMarketId: XMarketId);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<List<LegalAgreementResponse>>(JsonSettings);
        }

        /// <summary>
        /// Retrieve a list of Domains for the specified Shopper
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XShopperId"></param>
        /// <returns></returns>
        public async Task<List<DomainRetrieveResponse>> RetrieveDomainList(DomainRetrieve request, string XShopperId = null)
        {
            CheckRequestValid(request);
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"v1/domains{QueryStringBuilder.RequestObjectToQueryString(request)}");
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<List<DomainRetrieveResponse>>(JsonSettings);
        }

        /// <summary>
        /// Retrieves a list of TLDs supported and enabled for sale
        /// </summary>
        /// <returns></returns>
        public async Task<List<TldSummaryResponse>> RetrieveTldSummary()
        {
            var response = await httpClient.GetAsync("v1/domains/tlds");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<List<TldSummaryResponse>>(JsonSettings);
        }

        /// <summary>
        /// Purchase and start or restart transfer process
        /// </summary>
        /// <param name="request"></param>
        /// <param name="domain"></param>
        /// <param name="XShopperId"></param>
        /// <returns></returns>
        public async Task<DomainTransferIn> TransferDomain(DomainTransferIn request, string domain, string XShopperId = null)
        {
            CheckRequestValid(request);
            using var httpRequest = CreateJsonRequest(HttpMethod.Post, $"v1/domains/{domain}/transfer", request);
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainTransferIn>(JsonSettings);
        }

        /// <summary>
        /// Update details for the specified Domain
        /// </summary>
        /// <param name="request"></param>
        /// <param name="domain"></param>
        /// <param name="XShopperId"></param>
        /// <returns></returns>
        public async Task<bool> UpdateDomain(DomainUpdate request, string domain, string XShopperId = null)
        {
            CheckRequestValid(request);
            using var httpRequest = CreateJsonRequest(new HttpMethod("PATCH"), $"v1/domains/{domain}", request);
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId);
            await CheckResponseMessageIsValid(response);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Update contacts for the specified Domain
        /// </summary>
        /// <param name="request"></param>
        /// <param name="domain"></param>
        /// <param name="XShopperId"></param>
        /// <returns></returns>
        public async Task<bool> UpdateDomainContacts(DomainContacts request, string domain, string XShopperId = null)
        {
            CheckRequestValid(request);
            using var httpRequest = CreateJsonRequest(new HttpMethod("PATCH"), $"v1/domains/{domain}/contacts", request);
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId);
            await CheckResponseMessageIsValid(response);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Re-send Contact E-mail Verification for specified Domain
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XShopperId"></param>
        /// <returns></returns>
        public async Task<bool> VerifyRegistrantEmail(VerifyRegistrantEmail request, string XShopperId = null)
        {
            CheckRequestValid(request);
            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"v1/domains/{request.Domain}/verifyregistrantemail");
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId);
            await CheckResponseMessageIsValid(response);
            return response.IsSuccessStatusCode;
        }
    }
}
