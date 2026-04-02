using GodaddyWrapper.Helper;
using GodaddyWrapper.Requests;
using GodaddyWrapper.Responses;
using System.Net.Http;
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
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"orders{QueryStringBuilder.RequestObjectToQueryString(request)}");
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId, xMarketId: XMarketId);
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
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"orders/{request.OrderId}");
            var response = await SendRequestAsync(httpRequest, xShopperId: XShopperId, xMarketId: XMarketId);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<OrderResponse>(JsonSettings);
        }
    }
}
