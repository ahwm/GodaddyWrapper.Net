﻿using GodaddyWrapper.Helper;
using GodaddyWrapper.Requests;
using GodaddyWrapper.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GodaddyWrapper
{
    public partial class GoDaddyClient
    {
        /// <summary>
        /// Cancel a pending certificate
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task CancelCertificate(CertificateCancel request)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsync($"certificates/{request.CertificateId}/cancel", JsonConvert.SerializeObject(request, JsonSettings));
            await CheckResponseMessageIsValid(response);
        }
        /// <summary>
        /// Check Domain Control
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task CheckDomainControl(CertificateDomainControlCheck request)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsync($"certificates/{request.CertificateId}/verifydomaincontrol", null);
            await CheckResponseMessageIsValid(response);
        }
        /// <summary>
        /// Create a pending order for certificate
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XMarketId"></param>
        /// <returns></returns>
        public async Task<CertificateIdentifierResponse> CreateCertificate(CertificatesCreate request, string XMarketId = null)
        {
            CheckRequestValid(request);
            if (XMarketId != null)
                httpClient.DefaultRequestHeaders.Add("X-Market-Id", XMarketId);
            var response = await httpClient.PostAsync($"certificates", JsonConvert.SerializeObject(request, JsonSettings));
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CertificateIdentifierResponse>();
        }
        /// <summary>
        /// Download certificate
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CertificateBundleResponse> DownloadCertificate(CertificateDownload request)
        {
            CheckRequestValid(request);
            var response = await httpClient.GetAsync($"certificates/{request.CertificateId}/download");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CertificateBundleResponse>();
        }
        /// <summary>
        /// Reissue active certificate
        /// </summary>
        /// <param name="request"></param>
        /// <param name="certificateId"></param>
        /// <returns></returns>
        public async Task ReissueActiveCertificate(CertificateReissue request, string certificateId)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsync($"certificates/{certificateId}/reissue", JsonConvert.SerializeObject(request, JsonSettings));
            await CheckResponseMessageIsValid(response);
        }
        /// <summary>
        /// Renew active certificate
        /// </summary>
        /// <param name="request"></param>
        /// <param name="certificateId"></param>
        /// <returns></returns>
        public async Task RenewActiveCertificate(CertificateRenew request, string certificateId)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsync($"certificates/{certificateId}/renew", JsonConvert.SerializeObject(request, JsonSettings));
            await CheckResponseMessageIsValid(response);
        }
        /// <summary>
        /// Retrieve certificate detail
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<List<CertificateActionResponse>> RetrieveCertificateAction(CertificateActionRetrieve request)
        {
            CheckRequestValid(request);
            var response = await httpClient.GetAsync($"certificates/{request.CertificateId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<List<CertificateActionResponse>>();
        }
        /// <summary>
        /// Register of certificate action callback
        /// </summary>
        /// <param name="request"></param>
        /// <param name="certificateId"></param>
        /// <returns></returns>
        public async Task RegisterCertificateAction(CertificateCallbackActionRegister request, string certificateId)
        {
            CheckRequestValid(request);
            var response = await httpClient.PutAsync($"certificates/{certificateId}/callback", JsonConvert.SerializeObject(request, JsonSettings));
            await CheckResponseMessageIsValid(response);
        }
        /// <summary>
        /// Retrieve certificate details
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CertificateIdentifierResponse> RetrieveCertificateDetail(CertificateDetailRetrieve request)
        {
            CheckRequestValid(request);
            var response = await httpClient.GetAsync($"certificates/{request.CertificateId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CertificateIdentifierResponse>();
        }
        /// <summary>
        /// Get Site seal
        /// </summary>
        /// <param name="request"></param>
        /// <param name="certificateId"></param>
        /// <returns></returns>
        public async Task<CertificateSiteSealResponse> RetrieveSiteSeal(CertificateSiteSealRetrieve request, string certificateId)
        {
            CheckRequestValid(request);
            var response = await httpClient.GetAsync($"certificates/{certificateId}/siteseal");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CertificateSiteSealResponse>();
        }
        /// <summary>
        /// Revoke active certificate
        /// </summary>
        /// <param name="request"></param>
        /// <param name="certificateId"></param>
        /// <returns></returns>
        public async Task RevokeActiveCertificate(CertificateRevoke request, string certificateId)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsync($"certificates/{certificateId}/revoke", JsonConvert.SerializeObject(request, JsonSettings));
            await CheckResponseMessageIsValid(response);
        }
        /// <summary>
        /// Unregister system callback
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UnregisterCertificateCallback(CertificateCallbackUnregister request)
        {
            CheckRequestValid(request);
            var response = await httpClient.DeleteAsync($"certificates/{request.CertificateId}/callback");
            await CheckResponseMessageIsValid(response);
        }
    }
}
