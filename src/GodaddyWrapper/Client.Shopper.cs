using GodaddyWrapper.Helper;
using GodaddyWrapper.Requests;
using GodaddyWrapper.Responses;
using Newtonsoft.Json;
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
            var response = await httpClient.PostAsync($"shoppers/subaccount", JsonConvert.SerializeObject(request, JsonSettings));
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
            var response = await httpClient.GetAsync($"shoppers/{request.ShopperId}");
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
            var response = await httpClient.PostAsync($"shoppers/{shopperId}", JsonConvert.SerializeObject(request, JsonSettings));
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<ShopperIdResponse>();
        }
    }
}
