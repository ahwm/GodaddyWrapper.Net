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
using Newtonsoft.Json;

namespace GodaddyWrapper
{
    public partial class Client
    {
        /// <summary>
        /// Create a Subaccount owned by the authenticated Reseller
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ShopperIdResponse> CreateSubaccount(SubaccountCreate request)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            var response = await client.PostAsync($"shoppers/subaccount", JsonConvert.SerializeObject(request, JsonSettings));
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<ShopperIdResponse>();
        }
        /// <summary>
        /// Get details for the specified Shopper
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ShopperResponse> RetrieveShopper(ShopperRetrieve request)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            var response = await client.GetAsync($"shoppers/{request.ShopperId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<ShopperResponse>();
        }
        /// <summary>
        /// Update details for the specified Shopper
        /// </summary>
        /// <param name="request"></param>
        /// <param name="shopperId"></param>
        /// <returns></returns>
        public async Task<ShopperIdResponse> UpdateShopper(ShopperUpdate request, string shopperId)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            var response = await client.PostAsync($"shoppers/{shopperId}", JsonConvert.SerializeObject(request, JsonSettings));
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<ShopperIdResponse>();
        }


    }
}
