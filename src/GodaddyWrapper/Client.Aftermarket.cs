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
        /// Add expiry listings into GoDaddy Auction
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AftermarketListingActionResponse> AddExpiryAuction(List<AftermarketListingExpiryCreate> request)
        {
            var client = GetBaseHttpClient();
            var response = await client.PostAsync($"aftermarket/listings/expiry", request);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<AftermarketListingActionResponse>();
        }

        /// <summary>
        /// Remove listings from GoDaddy Auction
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListingActionResponse> RemoveAuctionListings(AggreementRetrieve request)
        {
            var client = GetBaseHttpClient();
            var response = await client.DeleteAsync($"aftermarket/listings{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<ListingActionResponse>();
        }

    }
}
