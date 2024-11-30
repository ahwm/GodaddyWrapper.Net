using GodaddyWrapper.Helper;
using GodaddyWrapper.Requests;
using GodaddyWrapper.Responses;
using System.Threading.Tasks;

namespace GodaddyWrapper
{
    public partial class GoDaddyClient
    {
        /// <summary>
        /// Retrieves summary country information for the provided marketId and filters
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CountrySummaryResponse> RetrieveCountries(CountriesRetrieve request)
        {
            CheckRequestValid(request);
            var response = await httpClient.GetAsync($"countries{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CountrySummaryResponse>(JsonSettings);
        }
        /// <summary>
        /// Retrieves country and summary state information for provided countryKey
        /// </summary>
        /// <param name="request"></param>
        /// <param name="CountryKey"></param>
        /// <returns></returns>
        public async Task<CountryResponse> RetrieveCountryDetail(CountryDetailRetrieve request, string CountryKey)
        {
            CheckRequestValid(request);
            var response = await httpClient.GetAsync($"countries/{CountryKey}{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<CountryResponse>(JsonSettings);
        }
    }
}
