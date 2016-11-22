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
        /// Retrieve a list of orders for the authenticated shopper. Only one filter may be used at a time
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XShopperId"></param>
        /// <param name="XMarketId"></param>
        /// <returns></returns>
        public async Task<OrderListResponse> RetrieveOrderList(OrderRetrieve request, string XShopperId, string XMarketId)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            if (XMarketId != null)
                client.DefaultRequestHeaders.Add("X-Market-Id", XMarketId);
            var response = await client.GetAsync($"orders{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<OrderListResponse>();
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
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            if (XMarketId != null)
                client.DefaultRequestHeaders.Add("X-Market-Id", XMarketId);
            var response = await client.GetAsync($"orders/{request.orderId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<OrderResponse>();
        }
    }
}
