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
        /// Retrieve Legal Agreements for provided agreements keys
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XPrivateLabelId"></param>
        /// <param name="XMarketId"></param>
        /// <returns></returns>
        public async Task<List<LegalAgreementResponse>> RetrieveAgreements(AgreementRetrieve request, string XPrivateLabelId = null, string XMarketId = null)
        {
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"aggreements{QueryStringBuilder.RequestObjectToQueryString(request)}");
            var response = await SendRequestAsync(httpRequest, xMarketId: XMarketId, xPrivateLabelId: XPrivateLabelId);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<List<LegalAgreementResponse>>(JsonSettings);
        }

    }
}
