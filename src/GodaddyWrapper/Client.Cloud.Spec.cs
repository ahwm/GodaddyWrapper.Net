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
        /// Get a list of specs
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudSpecListResponse> RetrieveCloudSpecs(CloudSpecsRetrieve request)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/specs{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudSpecListResponse>();
        }
        /// <summary>
        /// Find spec by spec specId
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudSpecResponse> RetrieveCloudSpecsDetail(CloudSpecsDetailRetrieve request)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/specs/{request.specId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudSpecResponse>();
        }

    }
}
