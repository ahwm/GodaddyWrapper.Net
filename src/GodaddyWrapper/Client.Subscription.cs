using GodaddyWrapper.Helper;
using GodaddyWrapper.Requests;
using GodaddyWrapper.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GodaddyWrapper
{
    public partial class GoDaddyClient
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
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await httpClient.DeleteAsync($"subscriptions/{request.SubscriptionId}");
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
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            if (XMarketId != null)
                httpClient.DefaultRequestHeaders.Add("X-Market-Id", XMarketId);
            var response = await httpClient.GetAsync($"subscriptions{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<SubscriptionListResponse>(JsonSettings);
        }
        /// <summary>
        /// Retrieve a list of ProductGroups for the specified Shopper
        /// </summary>
        /// <param name="XShopperId"></param>
        /// <param name="XMarketId"></param>
        /// <returns></returns>
        public async Task<List<ProductGroupResponse>> RetrieveSubscriptionProductGroups(string XShopperId = null, string XMarketId = null)
        {
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            if (XMarketId != null)
                httpClient.DefaultRequestHeaders.Add("X-Market-Id", XMarketId);
            var response = await httpClient.GetAsync($"subscriptions/productgroups");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<List<ProductGroupResponse>>(JsonSettings);
        }
        /// <summary>
        /// Retrieve details for the specified Subscription
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XShopperId"></param>
        /// <param name="XMarketId"></param>
        /// <returns></returns>
        public async Task<SubscriptionResponse> RetrieveSubscriptionDetails(SubscriptionDetailRetrieve request, string XShopperId = null, string XMarketId = null)
        {
            CheckRequestValid(request);
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            if (XMarketId != null)
                httpClient.DefaultRequestHeaders.Add("X-Market-Id", XMarketId);
            var response = await httpClient.GetAsync($"subscriptions/{request.SubscriptionId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<SubscriptionResponse>(JsonSettings);
        }
    }
}
