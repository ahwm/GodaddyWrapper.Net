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
        /// Create a new application
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudApplicationResponse> CreateApplication(CloudApplicationCreate request)
        {
            var client = GetBaseHttpClient();
            var response = await client.PostAsync($"cloud/applications", request);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudApplicationResponse>();
        }
        /// <summary>
        /// Get a list of applications
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudApplicationListResponse> RetrieveApplications(CloudApplicationCreate request)
        {
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/applications{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudApplicationListResponse>();
        }
        /// <summary>
        /// Find application by applicationId
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudApplicationResponse> RetrieveApplicationDetail(CloudApplicationDetailRetrieve request)
        {
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/applications/{request.ApplicationId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudApplicationResponse>();
        }
    }
}
