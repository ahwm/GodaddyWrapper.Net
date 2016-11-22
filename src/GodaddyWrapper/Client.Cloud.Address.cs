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
        /// Attach an address to a server
        /// </summary>
        /// <param name="request"></param>
        /// <param name="addressId"></param>
        /// <returns></returns>
        public async Task<CloudAddressActionResponse> AttachAddress(CloudAddressAttach request, string addressId)
        {
            var client = GetBaseHttpClient();
            var response = await client.PostAsync($"cloud/addresses/{addressId}/", request);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudAddressActionResponse>();
        }
        /// <summary>
        /// Create a new dynamic IPv4 address
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudIpAddressResponse> CreateAddress(CloudIpAddressCreate request)
        {
            var client = GetBaseHttpClient();
            var response = await client.PostAsync($"cloud/addresses", request);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudIpAddressResponse>();
        }
        /// <summary>
        /// Destroy an address
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudAddressActionResponse> DestroyAddress(CloudAddressDestroy request)
        {
            var client = GetBaseHttpClient();
            var response = await client.PostAsync($"cloud/addresses/{request.addressId}/destroy", null);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudAddressActionResponse>();
        }
        /// <summary>
        /// Detach an address from a server
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudAddressActionResponse> DetachAddress(CloudAddressDetach request)
        {
            var client = GetBaseHttpClient();
            var response = await client.PostAsync($"cloud/addresses/{request.addressId}/detach", null);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudAddressActionResponse>();
        }
        /// <summary>
        /// List actions performed on an Addres
        /// </summary>
        /// <param name="request"></param>
        /// <param name="addressId"></param>
        /// <returns></returns>
        public async Task<CloudAddressActionListResponse> RetrieveAddressActions(CloudAddressActionRetrieve request, string addressId)
        {
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/addresses/{addressId}/actions{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudAddressActionListResponse>();
        }
        /// <summary>
        /// Find AddressAction by id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudAddressActionResponse> RetrieveAddressActionDetail(CloudAddressActionDetailRetrieve request)
        {
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/addresses/{request.addressId}/actions/{request.addressActionId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudAddressActionResponse>();
        }
        /// <summary>
        /// Find address by id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudIpAddressResponse> RetrieveAddressDetail(CloudAddressDetailRetrieve request)
        {
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/addresses/{request.addressId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudIpAddressResponse>();
        }
        /// <summary>
        /// List addresses
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CloudAddressListResponse> RetrieveAddresses(CloudAddressRetrieve request)
        {
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"cloud/addresses{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CloudAddressListResponse>();
        }
    }
}
