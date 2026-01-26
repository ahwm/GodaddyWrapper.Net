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
            var response = await httpClient.PostAsJsonAsync($"{V1_BASE}shoppers/subaccount", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<ShopperIdResponse>(JsonSettings);
        }
        /// <summary>
        /// Get details for the specified Shopper
        /// </summary>
        /// <param name="request"></param>
        /// <param name="includes">Optional comma-separated list of additional fields (e.g., "customerId")</param>
        /// <returns></returns>
        public async Task<ShopperResponse> RetrieveShopper(ShopperRetrieve request, string includes = null)
        {
            CheckRequestValid(request);
            var url = $"{V1_BASE}shoppers/{request.ShopperId}";
            if (!string.IsNullOrEmpty(includes))
                url += $"?includes={includes}";
            var response = await httpClient.GetAsync(url);
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
            var response = await httpClient.PostAsJsonAsync($"{V1_BASE}shoppers/{shopperId}", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<ShopperIdResponse>(JsonSettings);
        }
    }
}
