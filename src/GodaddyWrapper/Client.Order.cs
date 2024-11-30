using GodaddyWrapper.Helper;
using GodaddyWrapper.Requests;
using GodaddyWrapper.Responses;
using System.Threading.Tasks;

namespace GodaddyWrapper
{
    public partial class GoDaddyClient
    {
        /// <summary>
        /// Retrieve a list of orders for the authenticated shopper. Only one filter may be used at a time
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XShopperId"></param>
        /// <param name="XMarketId"></param>
        /// <returns></returns>
        public async Task<OrderListResponse> RetrieveOrderList(OrderRetrieve request, string XShopperId, string XMarketId)
        {
            CheckRequestValid(request);
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            if (XMarketId != null)
                httpClient.DefaultRequestHeaders.Add("X-Market-Id", XMarketId);
            var response = await httpClient.GetAsync($"orders{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<OrderListResponse>(JsonSettings);
        }
        /// <summary>
        /// Retrieve details for specified order
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XShopperId"></param>
        /// <param name="XMarketId"></param>
        /// <returns></returns>
        public async Task<OrderResponse> RetrieveSpecificOrder(OrderDetailRetrieve request, string XShopperId, string XMarketId)
        {
            CheckRequestValid(request);
            if (XShopperId != null)
                httpClient.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            if (XMarketId != null)
                httpClient.DefaultRequestHeaders.Add("X-Market-Id", XMarketId);
            var response = await httpClient.GetAsync($"orders/{request.OrderId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<OrderResponse>(JsonSettings);
        }
    }
}
