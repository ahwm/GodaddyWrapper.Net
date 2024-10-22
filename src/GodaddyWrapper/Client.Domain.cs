using GodaddyWrapper.Helper;
using GodaddyWrapper.Requests;
using GodaddyWrapper.Responses;
using Newtonsoft.Json;
using System.Collections.Generic;
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
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await httpClient.PatchAsync($"domains/{domain}/records", JsonConvert.SerializeObject(request, JsonSettings));
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
            var response = await httpClient.PostAsync($"domains/available?checkType={request.CheckType}", JsonConvert.SerializeObject(request.Domains, JsonSettings));
            await CheckResponseMessageIsValid(response);
            if (response.StatusCode.ToString() == "203")
                return new DomainAvailableBulkResultResponse
                {
                    IsFullySuccessed = false,
                    BulkMixedDomain = await response.Content.ReadAsAsync<DomainAvailableBulkMixedResponse>()
                };
            else
                return new DomainAvailableBulkResultResponse
                {
                    IsFullySuccessed = true,
                    BulkDomain = await response.Content.ReadAsAsync<Responses.DomainAvailableBulkResponse>()
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
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await httpClient.DeleteAsync($"domains/{request.Domain}");
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
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await httpClient.DeleteAsync($"domains/{request.Domain}/privacy");
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
            return await response.Content.ReadAsAsync<DomainAvailableResponse>();
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
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await httpClient.PostAsync("domains/purchase", JsonConvert.SerializeObject(request, JsonSettings));
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainPurchaseResponse>();
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
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await httpClient.PostAsync("domains/purchase", JsonConvert.SerializeObject(request, JsonSettings));
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainPurchaseResponse>();
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
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await httpClient.PostAsync($"domains/{domain}/privacy/purchase", JsonConvert.SerializeObject(request, JsonSettings));
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainPurchaseResponse>();
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
            return await response.Content.ReadAsAsync<JsonPropertyResponse>();
        }
        /// <summary>
        /// Validate the request body using the Domain Purchase Schema for the specified TLD
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<bool> PurchaseDomainValidate(DomainPurchase request)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsync("domains/purchase/validate", JsonConvert.SerializeObject(request, JsonSettings));
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
            var response = await httpClient.PostAsync("domains/purchase/validate", JsonConvert.SerializeObject(request, JsonSettings));
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
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await httpClient.PostAsync($"domains/{domain}/renew", JsonConvert.SerializeObject(request, JsonSettings));
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainPurchaseResponse>();
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
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await httpClient.PutAsync($"domains/{domain}/records", JsonConvert.SerializeObject(request, JsonSettings));
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
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await httpClient.PutAsync($"domains/{domain}/records/{Type}", JsonConvert.SerializeObject(request, JsonSettings));
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
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await httpClient.PutAsync($"domains/{domain}/records/{Type}/{Name}", JsonConvert.SerializeObject(request, JsonSettings));
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
            if (XShopperId != null )
                httpClient.DefaultRequestHeaders.Add( "X-Shopper-Id", XShopperId );
            var response = await httpClient.DeleteAsync($"domains/{domain}/records/{Type}/{Name}");
            await CheckResponseMessageIsValid( response );
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
            if (XMarketId != null)
                httpClient.DefaultRequestHeaders.Add("X-Market-Id", XMarketId);
            var response = await httpClient.GetAsync($"domains/agreements{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<List<LegalAgreementResponse>>();
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
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await httpClient.GetAsync($"domains{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<List<DomainRetrieveResponse>>();
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
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await httpClient.GetAsync($"domains/{domain}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainDetailResponse>();
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
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            string urlPath = $"domains/{domain}/records/{Type}{(string.IsNullOrEmpty(Name) ? "" : $"/{Name}")}";
            var response = await httpClient.GetAsync($"{urlPath}{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<List<DNSRecordResponse>>();
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
            return await response.Content.ReadAsAsync<List<DomainSuggestionResponse>>();
        }
        /// <summary>
        /// Retrieves a list of TLDs supported and enabled for sale
        /// </summary>
        /// <returns></returns>
        public async Task<List<TldSummaryResponse>> RetrieveTldSummary()
        {
            var response = await httpClient.GetAsync("domains/tlds");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<List<TldSummaryResponse>>();
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
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await httpClient.PostAsync($"domains/{domain}/transfer", JsonConvert.SerializeObject(request, JsonSettings));
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainTransferIn>();
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
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await httpClient.PatchAsync($"domains/{domain}", JsonConvert.SerializeObject(request, JsonSettings));
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
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await httpClient.PatchAsync($"domains/{domain}/contacts", JsonConvert.SerializeObject(request, JsonSettings));
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
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await httpClient.PostAsync($"domains/{request.Domain}/verifyregistrantemail", null);
            await CheckResponseMessageIsValid(response);
            return response.IsSuccessStatusCode;
        }
    }
}
