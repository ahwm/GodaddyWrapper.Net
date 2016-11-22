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
        /// Applies the specified additions/changes to the target Shopper's Cart
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XShopperId"></param>
        /// <param name="XPrivateLabelId"></param>
        /// <param name="XMarketId"></param>
        /// <returns></returns>
        public async Task ApplyCartChanges(CartUpdateBulk request, string XShopperId = null, string XPrivateLabelId = null, string XMarketId = null)
        {
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            if (XPrivateLabelId != null)
                client.DefaultRequestHeaders.Add("X-Private-Label-Id", XPrivateLabelId);
            if (XMarketId != null)
                client.DefaultRequestHeaders.Add("X-Market-Id", XMarketId);
            var response = await client.PatchAsync($"cart", request);
            await CheckResponseMessageIsValid(response);
            return;
        }
        /// <summary>
        /// Clears contents of the target Shopper's Cart
        /// </summary>
        /// <param name="XShopperId"></param>
        /// <param name="XPrivateLabelId"></param>
        /// <param name="XMarketId"></param>
        /// <returns></returns>
        public async Task ClearCart(string XShopperId = null, string XPrivateLabelId = null, string XMarketId = null)
        {
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            if (XPrivateLabelId != null)
                client.DefaultRequestHeaders.Add("X-Private-Label-Id", XPrivateLabelId);
            if (XMarketId != null)
                client.DefaultRequestHeaders.Add("X-Market-Id", XMarketId);
            var response = await client.DeleteAsync($"cart");
            await CheckResponseMessageIsValid(response);
            return;
        }
        /// <summary>
        /// Expands listings and adds prices the supplied virtual cart
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XShopperId"></param>
        /// <param name="XPrivateLabelId"></param>
        /// <param name="XMarketId"></param>
        /// <param name="XCurrencyId"></param>
        /// <returns></returns>
        public async Task<CartResponse> ExpandCart(CartUpdateBulk request, string XShopperId = null, string XPrivateLabelId = null, string XMarketId = null, string XCurrencyId = null)
        {
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            if (XMarketId != null)
                client.DefaultRequestHeaders.Add("X-Market-Id", XMarketId);
            if (XPrivateLabelId != null)
                client.DefaultRequestHeaders.Add("X-Private-Label-Id", XPrivateLabelId);
            if (XCurrencyId != null)
                client.DefaultRequestHeaders.Add("X-Currency-Id", XCurrencyId);
            var response = await client.PostAsync($"cart/virtual/render", request);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CartResponse>();
        }
        /// <summary>
        /// Replace the target Shopper's Cart with source Shopper's Cart
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XShopperId"></param>
        /// <returns></returns>
        public async Task ReplaceCart(CartReplace request, string XShopperId = null)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            var response = await client.PostAsync($"cart/replace", request);
            await CheckResponseMessageIsValid(response);
            return;
        }
        /// <summary>
        /// Removes the specified CartGroup from the target Shopper's Cart
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XPrivateLabelId"></param>
        /// <returns></returns>
        public async Task RemoveCartGroup(CartGroupRemove request, string XPrivateLabelId = null)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            if (XPrivateLabelId != null)
                client.DefaultRequestHeaders.Add("X-Private-Label-Id", XPrivateLabelId);
            var response = await client.DeleteAsync($"cart/groups/{request.groupKey}");
            await CheckResponseMessageIsValid(response);
            return;
        }
        /// <summary>
        /// Removes the specified CartItem from the target Shopper's Cart
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XShopperId"></param>
        /// <param name="XPrivateLabelId"></param>
        /// <returns></returns>
        public async Task RemoveCartItem(CartItemRemove request, string XShopperId = null, string XPrivateLabelId = null)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            if (XPrivateLabelId != null)
                client.DefaultRequestHeaders.Add("X-Private-Label-Id", XPrivateLabelId);
            var response = await client.DeleteAsync($"cart/items/{request.itemId}");
            await CheckResponseMessageIsValid(response);
            return;
        }
        /// <summary>
        /// Removes multiple specified CartItems from the target Shopper's Cart
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XShopperId"></param>
        /// <param name="XPrivateLabelId"></param>
        /// <returns></returns>
        public async Task RemoveCartItems(CartItemListRemove request, string XShopperId = null, string XPrivateLabelId = null)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            if (XPrivateLabelId != null)
                client.DefaultRequestHeaders.Add("X-Private-Label-Id", XPrivateLabelId);
            var response = await client.DeleteAsync($"cart/items{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return;
        }
        /// <summary>
        /// Get contents of the target Shopper's Cart
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XShopperId"></param>
        /// <param name="XPrivateLabelId"></param>
        /// <param name="XMarketId"></param>
        /// <param name="XCurrencyId"></param>
        /// <returns></returns>
        public async Task<CartResponse> RetrieveCart(CartRetrieve request, string XShopperId = null, string XPrivateLabelId = null, string XMarketId = null, string XCurrencyId = null)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            if (XPrivateLabelId != null)
                client.DefaultRequestHeaders.Add("X-Private-Label-Id", XPrivateLabelId);
            if (XMarketId != null)
                client.DefaultRequestHeaders.Add("X-Market-Id", XMarketId);
            if (XCurrencyId != null)
                client.DefaultRequestHeaders.Add("X-Currency-Id", XCurrencyId);
            var response = await client.GetAsync($"cart{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CartResponse>();
        }
        /// <summary>
        /// Retrieves the schema which must be completed in order to purchase the specified product
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XPrivateLabelId"></param>
        /// <returns></returns>
        public async Task<JsonSchemaResponse> RetrievePurchaseSchema(CartPurchaseSchema request, string XPrivateLabelId = null)
        {
            CheckRequestValid(request);
            var client = GetBaseHttpClient();
            if (XPrivateLabelId != null)
                client.DefaultRequestHeaders.Add("X-Private-Label-Id", XPrivateLabelId);
            var response = await client.GetAsync($"cart/products/{request.pfid}/schema");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<JsonSchemaResponse>();
        }
        /// <summary>
        /// Performs product specific validation on the item metadata in the target Shopper's Cart
        /// </summary>
        /// <param name="XShopperId"></param>
        /// <param name="XMarketId"></param>
        /// <param name="XPrivateLabelId"></param>
        /// <returns></returns>
        public async Task ValidateCart(string XShopperId = null, string XMarketId = null, string XPrivateLabelId = null)
        {
            var client = GetBaseHttpClient();
            if (XShopperId != null)
                client.DefaultRequestHeaders.Add("X-Shopper-Id", XShopperId);
            if (XMarketId != null)
                client.DefaultRequestHeaders.Add("X-Market-Id", XMarketId);
            if (XPrivateLabelId != null)
                client.DefaultRequestHeaders.Add("X-Private-Label-Id", XPrivateLabelId);
            var response = await client.PostAsync($"cart/validate", null);
            await CheckResponseMessageIsValid(response);
            return;
        }
    }
}
