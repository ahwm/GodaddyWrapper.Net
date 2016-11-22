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
        /// Create a new server
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudServerResponse> CreateServer(CloudServerCreate request)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            var response = await client.PostAsync($"cloud/servers", request);
            await CheckResponseMessageIsValid(response); ;
            return await response.Content.ReadAsAsync<CloudServerResponse>();
        }
        /// <summary>
        /// Destroy an existing server
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudServerActionResponse> DestroyServer(CloudServerDestroy request)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            var response = await client.PostAsync($"cloud/servers/{request.serverId}/destroy", null);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudServerActionResponse>();
        }
        /// <summary>
        /// Get a console URL to this server
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudServerConsoleResponse> RetrieveConsoleURL(CloudServerConsoleURLRetrieve request)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/servers/{request.serverId}/console");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudServerConsoleResponse>();
        }
        /// <summary>
        /// Find Addresses by serverId and addressId
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudIpAddressResponse> RetrieveServerAddress(CloudServerAddressRetrieve request)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/servers/{request.serverId}/address/{request.addressId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudIpAddressResponse>();
        }
        /// <summary>
        /// List of Addresses of the specified server
        /// </summary>
        /// <param name="request"></param>
        /// <param name="serverId"></param>
        /// <returns></returns>
        public async Task<CloudServerListResponse> RetrieveServerAddresses(CloudServerAddressesRetrieve request, string serverId)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/servers/{serverId}/address{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudServerListResponse>();
        }
        /// <summary>
        /// Get a list of servers. By default, all destroyed servers are filtered out.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudServerListResponse> RetrieveServers(CloudServerRetrieve request)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/servers{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudServerListResponse>();
        }
        /// <summary>
        /// List of actions performed on the specified server
        /// </summary>
        /// <param name="request"></param>
        /// <param name="serverId"></param>
        /// <returns></returns>
        public async Task<CloudServerActionListResponse> RetrieveServerActions(CloudServerActionsRetrieve request, string serverId)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/servers/{serverId}/actions{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudServerActionListResponse>();
        }
        /// <summary>
        /// Get ServerAction by id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudServerActionResponse> RetrieveServerActionDetail(CloudServerActionDetailRetrieve request)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/servers/{request.serverId}/actions/{request.serverActionId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudServerActionResponse>();
        }
        /// <summary>
        /// Find server by serverId
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudServerResponse> RetrieveServerDetail(CloudServerDetailRetrieve request)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/servers/{request.serverId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudServerResponse>();
        }
        /// <summary>
        /// Find volume by serverId and volumeId
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudServerVolumeListResponse> RetrieveServerVolume(CloudServerVolumeRetrieve request)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/servers/{request.serverId}/volumes/{request.volumeId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudServerVolumeListResponse>();
        }
        /// <summary>
        /// Get a list of volumes for server
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudServerVolumeResponse> RetrieveServerVolumes(CloudServerVolumesRetrieve request)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/servers/{request.serverId}/volumes");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudServerVolumeResponse>();
        }
        /// <summary>
        /// Start a server
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudServerActionResponse> StartServer(CloudServerStart request)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            var response = await client.PostAsync($"cloud/servers/{request.serverId}/start", null);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudServerActionResponse>();
        }
        /// <summary>
        /// Stop a Server
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudServerActionResponse> StopServer(CloudServerStop request)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            var response = await client.PostAsync($"cloud/servers/{request.serverId}/stop", null);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudServerActionResponse>();
        }
        /// <summary>
        /// Update server details
        /// </summary>
        /// <param name="request"></param>
        /// <param name="serverId"></param>
        /// <returns></returns>
        public async Task<EmailPreferenceResponse> UpdateServerDetail(CloudServer request, string serverId)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            var response = await client.PatchAsync($"cloud/servers/{serverId}", request);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<EmailPreferenceResponse>();
        }
    }
}
