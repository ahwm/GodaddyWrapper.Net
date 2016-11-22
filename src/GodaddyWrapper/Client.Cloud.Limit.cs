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
        /// Get resource limits for your Cloud account
        /// </summary>
        /// <returns></returns>
        public async Task<CloudLimitsResponse> RetrieveAccountLimits()
        {
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/limits");
            await CheckResponseMessageIsValid(response); ;
            return await response.Content.ReadAsAsync<CloudLimitsResponse>();
        }
    }
}
