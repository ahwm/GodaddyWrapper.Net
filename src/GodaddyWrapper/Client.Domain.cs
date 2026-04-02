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
        /// Add the specified DNS Records to the specified Domain
        /// </summary>
        /// <param name="request"></param>
        /// <param name="domain"></param>
        /// <param name="XShopperId"></param>
        /// <returns></returns>
        public async Task<bool> AddDNSRecordsToDomain(List<DNSRecord> request,string domain, string XShopperId = null)
        {
            CheckRequestValid(request);
            using var httpRequest = CreateJsonRequest(new HttpMethod("PATCH"), $"domains/{domain}/records", request);
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId);
            await CheckResponseMessageIsValid(response);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Determine whether or not the specified domains are available for purchase
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DomainAvailableBulkResultResponse> BulkCheckDomainAvailable(Requests.DomainAvailableBulk request)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsJsonAsync($"domains/available?checkType={request.CheckType}", request.Domains, JsonSettings);
            await CheckResponseMessageIsValid(response);
            if (response.StatusCode.ToString() == "203")
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
            using var httpRequest = new HttpRequestMessage(HttpMethod.Delete, $"domains/{request.Domain}");
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
            using var httpRequest = new HttpRequestMessage(HttpMethod.Delete, $"domains/{request.Domain}/privacy");
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId);
            await CheckResponseMessageIsValid(response);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Determine whether or not the specified domain is available for purchase
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DomainAvailableResponse> CheckDomainAvailable(DomainAvailable request)
        {
            CheckRequestValid(request);
            var response = await httpClient.GetAsync($"domains/available{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainAvailableResponse>(JsonSettings);
        }

        /// <summary>
        /// Purchase and register the specified Domain
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XShopperId"></param>
        /// <returns></returns>
        public async Task<DomainPurchaseResponse> PurchaseDomain(DomainPurchase request, string XShopperId = null)
        {
            CheckRequestValid(request);
            using var httpRequest = CreateJsonRequest(HttpMethod.Post, "domains/purchase", request);
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainPurchaseResponse>(JsonSettings);
        }

        /// <summary>
        /// Purchase and register the specified Domain without privacy (For the Tld which is not support privacy)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XShopperId"></param>
        /// <returns></returns>
        public async Task<DomainPurchaseResponse> PurchaseDomainWithoutPrivacy(DomainPurchaseWithoutPrivacy request, string XShopperId = null)
        {
            CheckRequestValid(request);
            using var httpRequest = CreateJsonRequest(HttpMethod.Post, "domains/purchase", request);
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainPurchaseResponse>(JsonSettings);
        }

        /// <summary>
        /// Purchase privacy for a specified domain
        /// </summary>
        /// <param name="request"></param>
        /// <param name="domain"></param>
        /// <param name="XShopperId"></param>
        /// <returns></returns>
        public async Task<DomainPurchaseResponse> PurchasePrivacy(PrivacyPurchase request,string domain, string XShopperId = null)
        {
            CheckRequestValid(request);
            using var httpRequest = CreateJsonRequest(HttpMethod.Post, $"domains/{domain}/privacy/purchase", request);
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainPurchaseResponse>(JsonSettings);
        }

        /// <summary>
        /// Retrieve the schema to be submitted when registering a Domain for the specified TLD
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<JsonPropertyResponse> RetrieveDomainPurhcaseSchema(DomainPurchaseSchema request)
        {
            CheckRequestValid(request);
            var response = await httpClient.GetAsync($"domains/purchase/schema/{request.Tld}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<JsonPropertyResponse>(JsonSettings);
        }

        /// <summary>
        /// Validate the request body using the Domain Purchase Schema for the specified TLD
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<bool> PurchaseDomainValidate(DomainPurchase request)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsJsonAsync("domains/purchase/validate", request, JsonSettings);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Validate the request body using the Domain Purchase Schema for the specified TLD (For the Tld which is not support privacy)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<bool> PurchaseDomainValidateWithoutPrivacy(DomainPurchaseWithoutPrivacy request)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsJsonAsync("domains/purchase/validate", request, JsonSettings);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Renew the specified Domain
        /// </summary>
        /// <param name="request"></param>
        /// <param name="domain"></param>
        /// <param name="XShopperId"></param>
        /// <returns></returns>
        public async Task<DomainPurchaseResponse> RenewDomain(DomainRenew request,string domain, string XShopperId = null)
        {
            CheckRequestValid(request);
            using var httpRequest = CreateJsonRequest(HttpMethod.Post, $"domains/{domain}/renew", request);
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainPurchaseResponse>(JsonSettings);
        }

        /// <summary>
        /// Replace all DNS Records for the specified Domain
        /// </summary>
        /// <param name="request"></param>
        /// <param name="domain"></param>
        /// <param name="XShopperId"></param>
        /// <returns></returns>
        public async Task<bool> ReplaceDNSRecord(List<DNSRecord> request,string domain, string XShopperId = null)
        {
            CheckRequestValid(request);
            using var httpRequest = CreateJsonRequest(HttpMethod.Put, $"domains/{domain}/records", request);
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId);
            await CheckResponseMessageIsValid(response);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Replace all DNS Records for the specified Domain with the specified Type
        /// </summary>
        /// <param name="request"></param>
        /// <param name="domain"></param>
        /// <param name="Type"></param>
        /// <param name="XShopperId"></param>
        /// <returns></returns>
        public async Task<bool> ReplaceDNSRecordsWithType(List<DNSRecordCreateType> request,string domain, string Type, string XShopperId = null)
        {
            CheckRequestValid(request);
            using var httpRequest = CreateJsonRequest(HttpMethod.Put, $"domains/{domain}/records/{Type}", request);
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId);
            await CheckResponseMessageIsValid(response);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Replace all DNS Records for the specified Domain with the specified Type and Name
        /// </summary>
        /// <param name="request"></param>
        /// <param name="domain"></param>
        /// <param name="Type"></param>
        /// <param name="Name"></param>
        /// <param name="XShopperId"></param>
        /// <returns></returns>
        public async Task<bool> ReplaceDNSRecordsWithTypeAndName(List<DNSRecordCreateTypeName> request,string domain, string Type, string Name, string XShopperId = null)
        {
            CheckRequestValid(request);
            using var httpRequest = CreateJsonRequest(HttpMethod.Put, $"domains/{domain}/records/{Type}/{Name}", request);
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId);
            await CheckResponseMessageIsValid(response);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Delete DNS Record for the specified Domain with the specified Type and Name
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="Type"></param>
        /// <param name="Name"></param>
        /// <param name="XShopperId"></param>
        /// <returns></returns>
        public async Task<bool> RemoveDNSRecordWithTypeAndName(string domain, string Type, string Name, string XShopperId = null)
        {
            using var httpRequest = new HttpRequestMessage(HttpMethod.Delete, $"domains/{domain}/records/{Type}/{Name}");
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId);
            await CheckResponseMessageIsValid(response);
            return response.IsSuccessStatusCode;
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
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"domains/agreements{QueryStringBuilder.RequestObjectToQueryString(request)}");
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
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"domains{QueryStringBuilder.RequestObjectToQueryString(request)}");
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<List<DomainRetrieveResponse>>(JsonSettings);
        }

        /// <summary>
        /// Retrieve details for the specified Domain
        /// </summary>
        /// <param name="request"></param>
        /// <param name="domain"></param>
        /// <param name="Type"></param>
        /// <param name="Name"></param>
        /// <param name="XShopperId"></param>
        /// <returns></returns>
        public async Task<DomainDetailResponse> RetrieveDomainDetail(string domain, string XShopperId = null)
        {
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"domains/{domain}");
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainDetailResponse>(JsonSettings);
        }

        /// <summary>
        /// Retrieve DNS Records for the specified Domain, optionally with the specified Type and/or Name
        /// </summary>
        /// <param name="request"></param>
        /// <param name="domain"></param>
        /// <param name="Type"></param>
        /// <param name="Name"></param>
        /// <param name="XShopperId"></param>
        /// <returns></returns>
        public async Task<List<DNSRecordResponse>> RetrieveDNSRecordsWithTypeAndName(DNSRecordRetrieve request, string domain, string Type, string Name, string XShopperId = null)
        {
            CheckRequestValid(request);
            string urlPath = $"domains/{domain}/records/{Type}{(string.IsNullOrEmpty(Name) ? "" : $"/{Name}")}";
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{urlPath}{QueryStringBuilder.RequestObjectToQueryString(request)}");
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<List<DNSRecordResponse>>(JsonSettings);
        }

        /// <summary>
        /// Suggest alternate Domain names based on a seed Domain, a set of keywords, or the shopper's purchase history
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<List<DomainSuggestionResponse>> RetrieveSuggestDomain(DomainSuggest request)
        {
            CheckRequestValid(request);
            var response = await httpClient.GetAsync($"domains/suggest{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<List<DomainSuggestionResponse>>(JsonSettings);
        }

        /// <summary>
        /// Retrieves a list of TLDs supported and enabled for sale
        /// </summary>
        /// <returns></returns>
        public async Task<List<TldSummaryResponse>> RetrieveTldSummary()
        {
            var response = await httpClient.GetAsync("domains/tlds");
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
        public async Task<DomainTransferIn> TransferDomain(DomainTransferIn request,string domain, string XShopperId = null)
        {
            CheckRequestValid(request);
            using var httpRequest = CreateJsonRequest(HttpMethod.Post, $"domains/{domain}/transfer", request);
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
        public async Task<bool> UpdateDomain(DomainUpdate request,string domain, string XShopperId = null)
        {
            CheckRequestValid(request);
            using var httpRequest = CreateJsonRequest(new HttpMethod("PATCH"), $"domains/{domain}", request);
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId);
            await CheckResponseMessageIsValid(response);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Update domain
        /// </summary>
        /// <param name="request"></param>
        /// <param name="domain"></param>
        /// <param name="XShopperId"></param>
        /// <returns></returns>
        public async Task<bool> UpdateDomainContacts(DomainContacts request,string domain, string XShopperId = null)
        {
            CheckRequestValid(request);
            using var httpRequest = CreateJsonRequest(new HttpMethod("PATCH"), $"domains/{domain}/contacts", request);
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
            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"domains/{request.Domain}/verifyregistrantemail");
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId);
            await CheckResponseMessageIsValid(response);
            return response.IsSuccessStatusCode;
        }
    }
}
