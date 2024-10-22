using GodaddyWrapper.Helper;
using GodaddyWrapper.Requests;
using GodaddyWrapper.Responses;
using Newtonsoft.Json;
using System.Collections.Generic;
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
            var response = await httpClient.PostAsync($"aftermarket/listings/expiry", JsonConvert.SerializeObject(request, JsonSettings));
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<AftermarketListingActionResponse>();
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
            return await response.Content.ReadAsAsync<ListingActionResponse>();
        }

    }
}
