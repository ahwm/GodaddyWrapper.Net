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

namespace GodaddyWrapper
{
    public partial class Client
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
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await client.PatchAsync($"domains/{domain}/records", request);
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
            var client = GetBaseHttpClient();
            var response = await client.PostAsync("domains/available", request);
            await CheckResponseMessageIsValid(response); ;
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
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await client.DeleteAsync($"domains/{request.domain}");
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
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await client.DeleteAsync($"domains/{request.domain}/privacy");
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
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"domains/available{QueryStringBuilder.RequestObjectToQueryString(request)}");
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
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await client.PostAsync("domains/purchase", request);
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
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await client.PostAsync("domains/purchase", request);
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
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await client.PostAsync($"domains/{domain}/privacy/purchase", request);
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
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"domains/purchase/schema/{request.tld}");
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
            var client = GetBaseHttpClient();
            var response = await client.PostAsync("domains/purchase/validate", request);
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
            var client = GetBaseHttpClient();
            var response = await client.PostAsync("domains/purchase/validate", request);
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
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await client.PostAsync($"domains/{domain}/renew", request);
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
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await client.PutAsync($"domains/{domain}/records", request);
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
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await client.PutAsync($"domains/{domain}/records/{Type}", request);
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
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await client.PutAsync($"domains/{domain}/records/{Type}/{Name}", request);
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
            var client = GetBaseHttpClient();
            if (XMarketId != null)
                client.DefaultRequestHeaders.Add("X-Market-Id", XMarketId);
            var response = await client.GetAsync($"domains/agreements{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<List<LegalAgreementResponse>>();
        }
        /// <summary>
        /// Retrieve a list of Domains for the specified Shopper
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XShopperId"></param>
        /// <returns></returns>
        public async Task<bool> RetrieveDomainList(DomainRetrieve request, string XShopperId = null)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await client.GetAsync($"domains{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return response.IsSuccessStatusCode;
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
        public async Task<DomainDetailRetrieve> RetrieveDomainDetail(DomainDetailRetrieve request,string domain, string Type, string Name, string XShopperId = null)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await client.GetAsync($"domains/{domain}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainDetailRetrieve>();
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
        public async Task<List<DNSRecordResponse>> RetrieveDNSRecordsWithTypeAndName(DNSRecordRetrieve request,string domain, string Type, string Name, string XShopperId = null)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            string urlPath = "domains/{domain}/records";
            if (Name != null)
            {
                if (Name != null)
                    urlPath = $"domains/{domain}/records/{Type}";
                else
                    urlPath = $"domains/{domain}/records/{Type}/{Name}";
            }
            var response = await client.GetAsync($"{urlPath}{QueryStringBuilder.RequestObjectToQueryString(request)}");
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
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"domains/suggest{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<List<DomainSuggestionResponse>>();
        }
        /// <summary>
        /// Retrieves a list of TLDs supported and enabled for sale
        /// </summary>
        /// <returns></returns>
        public async Task<List<TldSummaryResponse>> RetrieveTldSummary()
        {
            var client = GetBaseHttpClient();
            var response = await client.GetAsync("domains/tlds");
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
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await client.PostAsync($"domains/{domain}/transfer", request);
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
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await client.PatchAsync($"domains/{domain}", request);
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
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await client.PatchAsync($"domains/{domain}/contacts", request);
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
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await client.PostAsync($"domains/{request.domain}/verifyregistrantemail", null);
            await CheckResponseMessageIsValid(response);
            return response.IsSuccessStatusCode;
        }
    }
}
