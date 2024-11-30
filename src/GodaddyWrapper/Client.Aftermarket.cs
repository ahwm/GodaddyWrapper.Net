using GodaddyWrapper.Helper;
using GodaddyWrapper.Requests;
using GodaddyWrapper.Responses;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace GodaddyWrapper
{
    public partial class GoDaddyClient
    {

        /// <summary>
        /// Add expiry listings into GoDaddy Auction
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AftermarketListingActionResponse> AddExpiryAuction(List<AftermarketListingExpiryCreate> request)
        {
            var response = await httpClient.PostAsJsonAsync($"aftermarket/listings/expiry", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<AftermarketListingActionResponse>(JsonSettings);
        }

        /// <summary>
        /// Remove listings from GoDaddy Auction
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListingActionResponse> RemoveAuctionListings(AgreementRetrieve request)
        {
            var response = await httpClient.DeleteAsync($"aftermarket/listings{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<ListingActionResponse>(JsonSettings);
        }

    }
}
