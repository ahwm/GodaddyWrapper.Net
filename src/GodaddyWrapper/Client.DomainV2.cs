using GodaddyWrapper.Helper;
using GodaddyWrapper.Requests;
using GodaddyWrapper.Responses;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace GodaddyWrapper
{
    /// <summary>
    /// GoDaddy Domain API v2 endpoints
    /// </summary>
    public partial class GoDaddyClient
    {

        /// <summary>
        /// Get domain details for a specific domain (v2)
        /// </summary>
        /// <param name="customerId">Customer ID (UUID). Can be retrieved via RetrieveShopper with includes="customerId"</param>
        /// <param name="domain">Domain name</param>
        /// <param name="includes">Optional comma-separated list of additional fields to include (nameServers, contacts, etc.)</param>
        /// <param name="XShopperId">Shopper ID to be operated on, if different from JWT</param>
        /// <returns>Domain details</returns>
        public async Task<DomainDetailResponse> GetDomainV2(string customerId, string domain, string includes = null, string XShopperId = null)
        {
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);

            var queryParams = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(includes))
                queryParams.Add("includes", includes);

            var queryString = QueryStringBuilder.DictionaryToQueryString(queryParams);
            var response = await httpClient.GetAsync($"{V2_BASE}customers/{customerId}/domains/{domain}{queryString}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainDetailResponse>(JsonSettings);
        }

        /// <summary>
        /// List domains for a customer (v2)
        /// </summary>
        /// <param name="customerId">Customer ID (UUID). Can be retrieved via RetrieveShopper with includes="customerId"</param>
        /// <param name="statuses">Filter by domain status (ACTIVE, PENDING, etc.)</param>
        /// <param name="statusGroups">Filter by domain status groups</param>
        /// <param name="limit">Maximum number of domains to return (default 1000)</param>
        /// <param name="marker">Marker for pagination</param>
        /// <param name="includes">Optional comma-separated list of additional fields to include</param>
        /// <param name="XShopperId">Shopper ID to be operated on, if different from JWT</param>
        /// <returns>List of domains</returns>
        public async Task<DomainListV2Response> ListDomainsV2(
            string customerId,
            string statuses = null,
            string statusGroups = null,
            int? limit = null,
            string marker = null,
            string includes = null,
            string XShopperId = null)
        {
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);

            var queryParams = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(statuses))
                queryParams.Add("statuses", statuses);
            if (!string.IsNullOrEmpty(statusGroups))
                queryParams.Add("statusGroups", statusGroups);
            if (limit.HasValue)
                queryParams.Add("limit", limit.Value.ToString());
            if (!string.IsNullOrEmpty(marker))
                queryParams.Add("marker", marker);
            if (!string.IsNullOrEmpty(includes))
                queryParams.Add("includes", includes);

            var queryString = QueryStringBuilder.DictionaryToQueryString(queryParams);
            var response = await httpClient.GetAsync($"{V2_BASE}customers/{customerId}/domains{queryString}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainListV2Response>(JsonSettings);
        }

        /// <summary>
        /// Update domain details (v2)
        /// </summary>
        /// <param name="customerId">Customer ID (UUID). Can be retrieved via RetrieveShopper with includes="customerId"</param>
        /// <param name="domain">Domain name</param>
        /// <param name="request">Domain update request</param>
        /// <param name="XShopperId">Shopper ID to be operated on, if different from JWT</param>
        /// <returns>Success status</returns>
        public async Task<bool> UpdateDomainV2(string customerId, string domain, DomainUpdateV2 request, string XShopperId = null)
        {
            CheckRequestValid(request);
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);

            var response = await httpClient.PatchAsJsonAsync($"{V2_BASE}customers/{customerId}/domains/{domain}", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Cancel domain (v2)
        /// </summary>
        /// <param name="customerId">Customer ID (UUID). Can be retrieved via RetrieveShopper with includes="customerId"</param>
        /// <param name="domain">Domain name</param>
        /// <param name="XShopperId">Shopper ID to be operated on, if different from JWT</param>
        /// <returns>Success status</returns>
        public async Task<bool> CancelDomainV2(string customerId, string domain, string XShopperId = null)
        {
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);

            var response = await httpClient.DeleteAsync($"{V2_BASE}customers/{customerId}/domains/{domain}");
            await CheckResponseMessageIsValid(response);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Get domain availability (v2)
        /// </summary>
        /// <param name="domain">Domain name to check</param>
        /// <param name="forTransfer">Whether to check for transfer availability</param>
        /// <returns>Domain availability information</returns>
        public async Task<DomainAvailabilityV2Response> CheckDomainAvailabilityV2(string domain, bool forTransfer = false)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "domain", domain }
            };
            if (forTransfer)
                queryParams.Add("forTransfer", "true");

            var queryString = QueryStringBuilder.DictionaryToQueryString(queryParams);
            var response = await httpClient.GetAsync($"{V2_BASE}domains/available{queryString}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainAvailabilityV2Response>(JsonSettings);
        }

        /// <summary>
        /// Purchase a domain (v2)
        /// </summary>
        /// <param name="customerId">Customer ID (UUID). Can be retrieved via RetrieveShopper with includes="customerId"</param>
        /// <param name="request">Domain purchase request</param>
        /// <param name="XShopperId">Shopper ID to be operated on, if different from JWT</param>
        /// <returns>Domain purchase response</returns>
        public async Task<DomainPurchaseV2Response> PurchaseDomainV2(string customerId, DomainPurchaseV2 request, string XShopperId = null)
        {
            CheckRequestValid(request);
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);

            var response = await httpClient.PostAsJsonAsync($"{V2_BASE}customers/{customerId}/domains/purchase", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainPurchaseV2Response>(JsonSettings);
        }

        /// <summary>
        /// Renew a domain (v2)
        /// </summary>
        /// <param name="customerId">Customer ID (UUID). Can be retrieved via RetrieveShopper with includes="customerId"</param>
        /// <param name="domain">Domain name</param>
        /// <param name="request">Domain renewal request</param>
        /// <param name="XShopperId">Shopper ID to be operated on, if different from JWT</param>
        /// <returns>Domain purchase response</returns>
        public async Task<DomainPurchaseV2Response> RenewDomainV2(string customerId, string domain, DomainRenewV2 request, string XShopperId = null)
        {
            CheckRequestValid(request);
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);

            var response = await httpClient.PostAsJsonAsync($"{V2_BASE}customers/{customerId}/domains/{domain}/renew", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainPurchaseV2Response>(JsonSettings);
        }

        /// <summary>
        /// Get DNS records for a domain (v2)
        /// </summary>
        /// <param name="customerId">Customer ID (UUID). Can be retrieved via RetrieveShopper with includes="customerId"</param>
        /// <param name="domain">Domain name</param>
        /// <param name="type">Record type filter (A, CNAME, MX, etc.)</param>
        /// <param name="name">Record name filter</param>
        /// <param name="XShopperId">Shopper ID to be operated on, if different from JWT</param>
        /// <returns>List of DNS records</returns>
        public async Task<List<DNSRecordResponse>> GetDNSRecordsV2(string customerId, string domain, string type = null, string name = null, string XShopperId = null)
        {
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);

            var path = $"{V2_BASE}customers/{customerId}/domains/{domain}/records";
            if (!string.IsNullOrEmpty(type))
            {
                path += $"/{type}";
                if (!string.IsNullOrEmpty(name))
                    path += $"/{name}";
            }

            var response = await httpClient.GetAsync(path);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<List<DNSRecordResponse>>(JsonSettings);
        }

        /// <summary>
        /// Replace all DNS records for a domain (v2)
        /// </summary>
        /// <param name="customerId">Customer ID (UUID). Can be retrieved via RetrieveShopper with includes="customerId"</param>
        /// <param name="domain">Domain name</param>
        /// <param name="records">List of DNS records</param>
        /// <param name="XShopperId">Shopper ID to be operated on, if different from JWT</param>
        /// <returns>Success status</returns>
        public async Task<bool> ReplaceDNSRecordsV2(string customerId, string domain, List<DNSRecord> records, string XShopperId = null)
        {
            CheckRequestValid(records);
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);

            var response = await httpClient.PutAsJsonAsync($"{V2_BASE}customers/{customerId}/domains/{domain}/records", records, JsonSettings);
            await CheckResponseMessageIsValid(response);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Add DNS records to a domain (v2)
        /// </summary>
        /// <param name="customerId">Customer ID (UUID). Can be retrieved via RetrieveShopper with includes="customerId"</param>
        /// <param name="domain">Domain name</param>
        /// <param name="records">List of DNS records to add</param>
        /// <param name="XShopperId">Shopper ID to be operated on, if different from JWT</param>
        /// <returns>Success status</returns>
        public async Task<bool> AddDNSRecordsV2(string customerId, string domain, List<DNSRecord> records, string XShopperId = null)
        {
            CheckRequestValid(records);
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);

            var response = await httpClient.PatchAsJsonAsync($"{V2_BASE}customers/{customerId}/domains/{domain}/records", records, JsonSettings);
            await CheckResponseMessageIsValid(response);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Update contacts for a domain (v2)
        /// </summary>
        /// <param name="customerId">Customer ID (UUID). Can be retrieved via RetrieveShopper with includes="customerId"</param>
        /// <param name="domain">Domain name</param>
        /// <param name="request">Domain contacts update request</param>
        /// <param name="XShopperId">Shopper ID to be operated on, if different from JWT</param>
        /// <returns>Success status</returns>
        public async Task<bool> UpdateDomainContactsV2(string customerId, string domain, DomainContactsV2 request, string XShopperId = null)
        {
            CheckRequestValid(request);
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);

            var response = await httpClient.PatchAsJsonAsync($"{V2_BASE}customers/{customerId}/domains/{domain}/contacts", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Transfer a domain in (v2)
        /// </summary>
        /// <param name="customerId">Customer ID (UUID). Can be retrieved via RetrieveShopper with includes="customerId"</param>
        /// <param name="request">Domain transfer request</param>
        /// <param name="XShopperId">Shopper ID to be operated on, if different from JWT</param>
        /// <returns>Domain transfer response</returns>
        public async Task<DomainTransferV2Response> TransferDomainV2(string customerId, DomainTransferV2 request, string XShopperId = null)
        {
            CheckRequestValid(request);
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);

            var response = await httpClient.PostAsJsonAsync($"{V2_BASE}customers/{customerId}/domains/transfer", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainTransferV2Response>(JsonSettings);
        }
    }
}
