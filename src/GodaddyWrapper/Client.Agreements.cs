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
        /// Retrieve Legal Agreements for provided agreements keys
        /// </summary>
        /// <param name="request"></param>
        /// <param name="XPrivateLabelId"></param>
        /// <param name="XMarketId"></param>
        /// <returns></returns>
        public async Task<List<LegalAgreementResponse>> RetrieveAgreements(AgreementRetrieve request, string XPrivateLabelId = null, string XMarketId = null)
        {
            if (XPrivateLabelId != null)
                httpClient.DefaultRequestHeaders.Add("X-Private-Label-Id", XPrivateLabelId);
            if (XMarketId != null)
                httpClient.DefaultRequestHeaders.Add("X-Market-Id", XMarketId);
            var response = await httpClient.GetAsync($"aggreements{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<List<LegalAgreementResponse>>();
        }

    }
}
