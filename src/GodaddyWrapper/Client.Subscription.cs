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
        /// Cancel the specified Subscription
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XShopperId"></param>
        /// <returns></returns>
        public async Task<bool> CancelSubscription(SubscriptionDelete request, string XShopperId = null)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await client.DeleteAsync($"subscriptions/{request.subscriptionId}");
            await CheckResponseMessageIsValid(response);
            return response.IsSuccessStatusCode;
        }
        /// <summary>
        /// Retrieve a list of Subscriptions for the specified Shopper
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XShopperId"></param>
        /// <param name="XMarketId"></param>
        /// <returns></returns>
        public async Task<SubscriptionListResponse> RetrieveSubscriptions(SubscriptionRetrieve request, string XShopperId = null, string XMarketId = null)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            if (XMarketId != null)
                client.DefaultRequestHeaders.Add("X-Market-Id", XMarketId);
            var response = await client.GetAsync($"subscriptions{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<SubscriptionListResponse>();
        }
        /// <summary>
        /// Retrieve a list of ProductGroups for the specified Shopper
        /// </summary>
        /// <param name="XShopperId"></param>
        /// <param name="XMarketId"></param>
        /// <returns></returns>
        public async Task<List<ProductGroupResponse>> RetrieveSubscriptionProductGroups(string XShopperId = null, string XMarketId = null)
        {
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            if (XMarketId != null)
                client.DefaultRequestHeaders.Add("X-Market-Id", XMarketId);
            var response = await client.GetAsync($"subscriptions/productgroups");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<List<ProductGroupResponse>>();
        }
        /// <summary>
        /// Retrieve details for the specified Subscription
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XShopperId"></param>
        /// <param name="XMarketId"></param>
        /// <returns></returns>
        public async Task<SubscriptionResponse> RetrieveSubscriptionDetails(SubscriptionRetrieveDetail request, string XShopperId = null, string XMarketId = null)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            if (XMarketId != null)
                client.DefaultRequestHeaders.Add("X-Market-Id", XMarketId);
            var response = await client.GetAsync($"subscriptions/{request.subscriptionId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<SubscriptionResponse>();
        }
    }
}
