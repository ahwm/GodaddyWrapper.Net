using GodaddyWrapper.Helper;
using GodaddyWrapper.Requests;
using GodaddyWrapper.Responses;
using System.Collections.Generic;
using System.Net.Http;
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
            using var httpRequest = new HttpRequestMessage(HttpMethod.Delete, $"subscriptions/{request.SubscriptionId}");
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId);
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
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"subscriptions{QueryStringBuilder.RequestObjectToQueryString(request)}");
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId, xMarketId: XMarketId);
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
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, "subscriptions/productgroups");
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId, xMarketId: XMarketId);
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
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"subscriptions/{request.SubscriptionId}");
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId, xMarketId: XMarketId);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<SubscriptionResponse>(JsonSettings);
        }
    }
}
