using GodaddyWrapper.Helper;
using GodaddyWrapper.Requests;
using GodaddyWrapper.Responses;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace GodaddyWrapper
{
    public partial class GoDaddyClient
    {
        /// <summary>
        /// Search for certificate details by entitlement (v2)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<List<CertificateResponse>> GetCertificatesByEntitlement(CertificatesByEntitlementRetrieve request)
        {
            CheckRequestValid(request);
            var response = await httpClient.GetAsync($"../v2/certificates{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<List<CertificateResponse>>(JsonSettings);
        }

        /// <summary>
        /// Create a pending order for certificate using a subscription (v2)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="xMarketId"></param>
        /// <returns></returns>
        public async Task<SubscriptionCertificateIdentifierResponse> CreateSubscriptionCertificate(SubscriptionCertificateCreate request, string xMarketId = null)
        {
            CheckRequestValid(request);
            if (xMarketId != null)
                httpClient.DefaultRequestHeaders.Add("X-Market-Id", xMarketId);
            var response = await httpClient.PostAsJsonAsync($"../v2/certificates", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<SubscriptionCertificateIdentifierResponse>(JsonSettings);
        }

        /// <summary>
        /// Reissue active certificate (v2)
        /// </summary>
        /// <param name="certificateId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task ReissueActiveCertificateV2(string certificateId, CertificateReissueV2 request)
        {
            var response = await httpClient.PostAsJsonAsync($"../v2/certificates/{certificateId}/reissue", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Download certificate by entitlement (v2)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CertificateBundleResponse> DownloadCertificateByEntitlement(CertificateDownloadByEntitlementRetrieve request)
        {
            CheckRequestValid(request);
            var response = await httpClient.GetAsync($"../v2/certificates/download{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CertificateBundleResponse>(JsonSettings);
        }

        /// <summary>
        /// Retrieve certificates for a customer (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CertificateSummariesV2Response> GetCustomerCertificates(string customerId, CustomerCertificatesRetrieve request)
        {
            var response = await httpClient.GetAsync($"../v2/customers/{customerId}/certificates{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CertificateSummariesV2Response>(JsonSettings);
        }

        /// <summary>
        /// Retrieve individual certificate details for a customer (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="certificateId"></param>
        /// <returns></returns>
        public async Task<CertificateDetailV2Response> GetCustomerCertificateDetail(string customerId, string certificateId)
        {
            var response = await httpClient.GetAsync($"../v2/customers/{customerId}/certificates/{certificateId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CertificateDetailV2Response>(JsonSettings);
        }

        /// <summary>
        /// Retrieve domain verification status for a certificate (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="certificateId"></param>
        /// <returns></returns>
        public async Task<List<DomainVerificationSummaryResponse>> GetCertificateDomainVerifications(string customerId, string certificateId)
        {
            var response = await httpClient.GetAsync($"../v2/customers/{customerId}/certificates/{certificateId}/domainVerifications");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<List<DomainVerificationSummaryResponse>>(JsonSettings);
        }

        /// <summary>
        /// Retrieve detailed domain verification information for a specific domain (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="certificateId"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public async Task<DomainVerificationDetailResponse> GetCertificateDomainVerificationDetail(string customerId, string certificateId, string domain)
        {
            var response = await httpClient.GetAsync($"../v2/customers/{customerId}/certificates/{certificateId}/domainVerifications/{domain}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainVerificationDetailResponse>(JsonSettings);
        }

        /// <summary>
        /// Retrieve ACME external account binding for a customer (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<ExternalAccountBindingResponse> GetAcmeExternalAccountBinding(string customerId)
        {
            var response = await httpClient.GetAsync($"../v2/customers/{customerId}/certificates/acme/externalAccountBinding");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<ExternalAccountBindingResponse>(JsonSettings);
        }

        /// <summary>
        /// Search certificate subscriptions by domain (v2)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CertificatesByDomainPageResponse> SearchCertificateSubscriptions(CertificateSubscriptionsSearch request)
        {
            var response = await httpClient.GetAsync($"../v2/certificates/subscriptions/search{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CertificatesByDomainPageResponse>(JsonSettings);
        }

        /// <summary>
        /// Get certificates for a specific subscription (v2)
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CertificatesByDomainPagedResponse> GetCertificateSubscription(string guid, CertificateSubscriptionsSearch request)
        {
            var response = await httpClient.GetAsync($"../v2/certificates/subscription/{guid}{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CertificatesByDomainPagedResponse>(JsonSettings);
        }
    }
}
