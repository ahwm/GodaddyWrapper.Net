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
        /// Cancel a pending certificate (v1)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task CancelCertificate(CertificateCancel request)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsJsonAsync($"{V1_BASE}certificates/{request.CertificateId}/cancel", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Cancel a pending certificate (v2)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task CancelCertificateV2(CertificateCancel request)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsJsonAsync($"{V2_BASE}certificates/{request.CertificateId}/cancel", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Check Domain Control (v1)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task CheckDomainControl(CertificateDomainControlCheck request)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsync($"{V1_BASE}certificates/{request.CertificateId}/verifydomaincontrol", null);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Check Domain Control (v2)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task CheckDomainControlV2(CertificateDomainControlCheck request)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsync($"{V2_BASE}certificates/{request.CertificateId}/verifydomaincontrol", null);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Create a pending order for certificate (v1)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XMarketId"></param>
        /// <returns></returns>
        public async Task<CertificateIdentifierResponse> CreateCertificate(CertificatesCreate request, string XMarketId = null)
        {
            CheckRequestValid(request);
            if (XMarketId != null)
                httpClient.DefaultRequestHeaders.Add("X-Market-Id", XMarketId);
            var response = await httpClient.PostAsJsonAsync($"{V1_BASE}certificates", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CertificateIdentifierResponse>(JsonSettings);
        }

        /// <summary>
        /// Create a pending order for certificate (v2)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XMarketId"></param>
        /// <returns></returns>
        public async Task<CertificateIdentifierResponse> CreateCertificateV2(CertificatesCreate request, string XMarketId = null)
        {
            CheckRequestValid(request);
            if (XMarketId != null)
                httpClient.DefaultRequestHeaders.Add("X-Market-Id", XMarketId);
            var response = await httpClient.PostAsJsonAsync($"{V2_BASE}certificates", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CertificateIdentifierResponse>(JsonSettings);
        }

        /// <summary>
        /// Download certificate (v1)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CertificateBundleResponse> DownloadCertificate(CertificateDownload request)
        {
            CheckRequestValid(request);
            var response = await httpClient.GetAsync($"{V1_BASE}certificates/{request.CertificateId}/download");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CertificateBundleResponse>(JsonSettings);
        }

        /// <summary>
        /// Download certificate (v2)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CertificateBundleResponse> DownloadCertificateV2(CertificateDownload request)
        {
            CheckRequestValid(request);
            var response = await httpClient.GetAsync($"{V2_BASE}certificates/{request.CertificateId}/download");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CertificateBundleResponse>(JsonSettings);
        }

        /// <summary>
        /// Reissue active certificate (v1)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="certificateId"></param>
        /// <returns></returns>
        public async Task ReissueActiveCertificate(CertificateReissue request, string certificateId)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsJsonAsync($"{V1_BASE}certificates/{certificateId}/reissue", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Reissue active certificate (v2)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="certificateId"></param>
        /// <returns></returns>
        public async Task ReissueActiveCertificateV2(CertificateReissue request, string certificateId)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsJsonAsync($"{V2_BASE}certificates/{certificateId}/reissue", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Renew active certificate (v1)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="certificateId"></param>
        /// <returns></returns>
        public async Task RenewActiveCertificate(CertificateRenew request, string certificateId)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsJsonAsync($"{V1_BASE}certificates/{certificateId}/renew", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Renew active certificate (v2)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="certificateId"></param>
        /// <returns></returns>
        public async Task RenewActiveCertificateV2(CertificateRenew request, string certificateId)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsJsonAsync($"{V2_BASE}certificates/{certificateId}/renew", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Retrieve certificate detail (v1)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<List<CertificateActionResponse>> RetrieveCertificateAction(CertificateActionRetrieve request)
        {
            CheckRequestValid(request);
            var response = await httpClient.GetAsync($"{V1_BASE}certificates/{request.CertificateId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<List<CertificateActionResponse>>(JsonSettings);
        }

        /// <summary>
        /// Retrieve certificate detail (v2)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<List<CertificateActionResponse>> RetrieveCertificateActionV2(CertificateActionRetrieve request)
        {
            CheckRequestValid(request);
            var response = await httpClient.GetAsync($"{V2_BASE}certificates/{request.CertificateId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<List<CertificateActionResponse>>(JsonSettings);
        }

        /// <summary>
        /// Register of certificate action callback (v1)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="certificateId"></param>
        /// <returns></returns>
        public async Task RegisterCertificateAction(CertificateCallbackActionRegister request, string certificateId)
        {
            CheckRequestValid(request);
            var response = await httpClient.PutAsJsonAsync($"{V1_BASE}certificates/{certificateId}/callback", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Register of certificate action callback (v2)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="certificateId"></param>
        /// <returns></returns>
        public async Task RegisterCertificateActionV2(CertificateCallbackActionRegister request, string certificateId)
        {
            CheckRequestValid(request);
            var response = await httpClient.PutAsJsonAsync($"{V2_BASE}certificates/{certificateId}/callback", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Retrieve certificate details (v1)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CertificateIdentifierResponse> RetrieveCertificateDetail(CertificateDetailRetrieve request)
        {
            CheckRequestValid(request);
            var response = await httpClient.GetAsync($"{V1_BASE}certificates/{request.CertificateId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CertificateIdentifierResponse>(JsonSettings);
        }

        /// <summary>
        /// Retrieve certificate details (v2)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CertificateIdentifierResponse> RetrieveCertificateDetailV2(CertificateDetailRetrieve request)
        {
            CheckRequestValid(request);
            var response = await httpClient.GetAsync($"{V2_BASE}certificates/{request.CertificateId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CertificateIdentifierResponse>(JsonSettings);
        }

        /// <summary>
        /// Get Site seal (v1)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="certificateId"></param>
        /// <returns></returns>
        public async Task<CertificateSiteSealResponse> RetrieveSiteSeal(CertificateSiteSealRetrieve request, string certificateId)
        {
            CheckRequestValid(request);
            var response = await httpClient.GetAsync($"{V1_BASE}certificates/{certificateId}/siteseal");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CertificateSiteSealResponse>(JsonSettings);
        }

        /// <summary>
        /// Get Site seal (v2)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="certificateId"></param>
        /// <returns></returns>
        public async Task<CertificateSiteSealResponse> RetrieveSiteSealV2(CertificateSiteSealRetrieve request, string certificateId)
        {
            CheckRequestValid(request);
            var response = await httpClient.GetAsync($"{V2_BASE}certificates/{certificateId}/siteseal");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CertificateSiteSealResponse>(JsonSettings);
        }

        /// <summary>
        /// Revoke active certificate (v1)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="certificateId"></param>
        /// <returns></returns>
        public async Task RevokeActiveCertificate(CertificateRevoke request, string certificateId)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsJsonAsync($"{V1_BASE}certificates/{certificateId}/revoke", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Revoke active certificate (v2)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="certificateId"></param>
        /// <returns></returns>
        public async Task RevokeActiveCertificateV2(CertificateRevoke request, string certificateId)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsJsonAsync($"{V2_BASE}certificates/{certificateId}/revoke", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Unregister system callback (v1)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UnregisterCertificateCallback(CertificateCallbackUnregister request)
        {
            CheckRequestValid(request);
            var response = await httpClient.DeleteAsync($"{V1_BASE}certificates/{request.CertificateId}/callback");
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Unregister system callback (v2)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UnregisterCertificateCallbackV2(CertificateCallbackUnregister request)
        {
            CheckRequestValid(request);
            var response = await httpClient.DeleteAsync($"{V2_BASE}certificates/{request.CertificateId}/callback");
            await CheckResponseMessageIsValid(response);
        }
    }
}
