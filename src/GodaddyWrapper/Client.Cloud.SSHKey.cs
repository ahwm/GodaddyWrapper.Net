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
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudSSHKeyResponse> CreateSSHKey(CloudSSHKeyCreate request)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            var response = await client.PostAsync($"cloud/sshkeys", request);
            await CheckResponseMessageIsValid(response); ;
            return await response.Content.ReadAsAsync<CloudSSHKeyResponse>();
        }
        /// <summary>
        /// Delete a SSH key resource
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<bool> DeleteSSHKey(CloudSSHKeyDelete request)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            var response = await client.DeleteAsync($"cloud/sshkeys/{request.SshKeyId}");
            return response.IsSuccessStatusCode;
        }
        /// <summary>
        /// Get a list of SSH keys
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudSSHKeyListResponse> RetreieveSSHKeys(CloudSSHKeyRetrieve request)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/sshkeys{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudSSHKeyListResponse>();
        }
        /// <summary>
        /// Find SSH key by sshKeyId
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudSSHKeyResponse> RetreieveSSHKeyDetail(CloudSSHKeyDetailRetrieve request)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/sshkeys/{request.SshKeyId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudSSHKeyResponse>();
        }
    }
}
