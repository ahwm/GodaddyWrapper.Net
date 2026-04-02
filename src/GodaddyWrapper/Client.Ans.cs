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
        /// Search the ANS registry with flexible criteria
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AgentSearchResponse> SearchAgents(AgentSearch request)
        {
            var response = await httpClient.GetAsync($"agents{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<AgentSearchResponse>(JsonSettings);
        }

        /// <summary>
        /// Register a new agent with the ANS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AgentRegistrationPendingResponse> RegisterAgent(AgentRegister request)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsJsonAsync($"agents/register", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<AgentRegistrationPendingResponse>(JsonSettings);
        }

        /// <summary>
        /// Resolve an ANSName to an endpoint
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AgentResolutionResponse> ResolveAgent(AgentCapabilityRequest request)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsJsonAsync($"agents/resolution", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<AgentResolutionResponse>(JsonSettings);
        }

        /// <summary>
        /// Get agent details by agent ID
        /// </summary>
        /// <param name="agentId"></param>
        /// <returns></returns>
        public async Task<AgentDetailsResponse> GetAgent(string agentId)
        {
            var response = await httpClient.GetAsync($"agents/{agentId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<AgentDetailsResponse>(JsonSettings);
        }

        /// <summary>
        /// Revoke an active agent or cancel a pending registration
        /// </summary>
        /// <param name="agentId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AgentRevocationResponse> RevokeAgent(string agentId, AgentRevoke request)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsJsonAsync($"agents/{agentId}/revoke", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<AgentRevocationResponse>(JsonSettings);
        }

        /// <summary>
        /// Trigger ACME domain validation for an agent
        /// </summary>
        /// <param name="agentId"></param>
        /// <returns></returns>
        public async Task<AgentStatusResponse> VerifyAgentAcme(string agentId)
        {
            var response = await httpClient.PostAsync($"agents/{agentId}/verify-acme", null);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<AgentStatusResponse>(JsonSettings);
        }

        /// <summary>
        /// Verify DNS records configured for an agent
        /// </summary>
        /// <param name="agentId"></param>
        /// <returns></returns>
        public async Task<AgentStatusResponse> VerifyAgentDns(string agentId)
        {
            var response = await httpClient.PostAsync($"agents/{agentId}/verify-dns", null);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<AgentStatusResponse>(JsonSettings);
        }

        /// <summary>
        /// Get all identity certificates for an agent
        /// </summary>
        /// <param name="agentId"></param>
        /// <returns></returns>
        public async Task<List<AgentCertificateResponse>> GetAgentIdentityCertificates(string agentId)
        {
            var response = await httpClient.GetAsync($"agents/{agentId}/certificates/identity");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<List<AgentCertificateResponse>>(JsonSettings);
        }

        /// <summary>
        /// Submit an identity certificate CSR for an agent
        /// </summary>
        /// <param name="agentId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AgentCsrSubmissionResponse> SubmitAgentIdentityCsr(string agentId, AgentCsrSubmit request)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsJsonAsync($"agents/{agentId}/certificates/identity", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<AgentCsrSubmissionResponse>(JsonSettings);
        }

        /// <summary>
        /// Get all server certificates for an agent
        /// </summary>
        /// <param name="agentId"></param>
        /// <returns></returns>
        public async Task<List<AgentCertificateResponse>> GetAgentServerCertificates(string agentId)
        {
            var response = await httpClient.GetAsync($"agents/{agentId}/certificates/server");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<List<AgentCertificateResponse>>(JsonSettings);
        }

        /// <summary>
        /// Submit a server certificate CSR for an agent
        /// </summary>
        /// <param name="agentId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AgentCsrSubmissionResponse> SubmitAgentServerCsr(string agentId, AgentCsrSubmit request)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsJsonAsync($"agents/{agentId}/certificates/server", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<AgentCsrSubmissionResponse>(JsonSettings);
        }

        /// <summary>
        /// Get CSR status for an agent
        /// </summary>
        /// <param name="agentId"></param>
        /// <param name="csrId"></param>
        /// <returns></returns>
        public async Task<AgentCsrStatusResponse> GetAgentCsrStatus(string agentId, string csrId)
        {
            var response = await httpClient.GetAsync($"agents/{agentId}/csrs/{csrId}/status");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<AgentCsrStatusResponse>(JsonSettings);
        }

        /// <summary>
        /// Retrieve ANS agent events
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AgentEventPageResponse> GetAgentEvents(AgentEventsRetrieve request)
        {
            var response = await httpClient.GetAsync($"agents/events{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<AgentEventPageResponse>(JsonSettings);
        }
    }
}
