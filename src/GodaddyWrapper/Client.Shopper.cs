using GodaddyWrapper.Helper;
using GodaddyWrapper.Requests;
using GodaddyWrapper.Responses;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace GodaddyWrapper
{
    public partial class GoDaddyClient
    {
        /// <summary>
        /// Create a Subaccount owned by the authenticated Reseller
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ShopperIdResponse> CreateSubaccount(SubaccountCreate request)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsJsonAsync($"shoppers/subaccount", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<ShopperIdResponse>(JsonSettings);
        }
        /// <summary>
        /// Get details for the specified Shopper
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ShopperResponse> RetrieveShopper(ShopperRetrieve request)
        {
            CheckRequestValid(request);
            var response = await httpClient.GetAsync($"shoppers/{request.ShopperId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<ShopperResponse>(JsonSettings);
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
            var response = await httpClient.PostAsJsonAsync($"shoppers/{shopperId}", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<ShopperIdResponse>(JsonSettings);
        }
    }
}
