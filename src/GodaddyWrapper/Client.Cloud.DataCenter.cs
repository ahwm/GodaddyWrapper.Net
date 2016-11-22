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
        /// Get a list of data centers
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudDataCenterListResponse> RetrieveDataCenters(CloudDataCenterRetrieve request)
        {
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/datacenters{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudDataCenterListResponse>();
        }
        /// <summary>
        /// Find data center by dataCenterId
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudDataCenterResponse> RetrieveDataCentersDetail(CloudDataCenterDetailRetrieve request)
        {
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/datacenters/{request.dataCenterId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudDataCenterResponse>();
        }
        /// <summary>
        /// List of zones in data center
        /// </summary>
        /// <param name="request"></param>
        /// <param name="dataCenterId"></param>
        /// <returns></returns>
        public async Task<CloudZoneListResponse> RetrieveDataCenterZones(CloudDataCenterZoneRetrieve request, string dataCenterId)
        {
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/datacenters/{dataCenterId}/zones{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudZoneListResponse>();
        }
        /// <summary>
        /// Get Zone by id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudZoneResponse> RetrieveDataCenterZoneDetail(CloudDataCenterZoneDetailRetrieve request)
        {
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/datacenters/{request.dataCenterId}/zones/{request.zoneId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudZoneResponse>();
        }
    }
}
