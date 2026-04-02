using GodaddyWrapper.Helper;
using GodaddyWrapper.Requests;
using GodaddyWrapper.Responses;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace GodaddyWrapper
{
    public partial class GoDaddyClient
    {
        /// <summary>
        /// Create a new abuse ticket (v2)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AbuseTicketIdResponse> CreateAbuseTicketV2(AbuseTicketCreateV2 request)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsJsonAsync($"../v2/abuse/tickets", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<AbuseTicketIdResponse>(JsonSettings);
        }

        /// <summary>
        /// List all abuse ticket ids that match user provided filters (v2)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AbuseTicketListResponse> RetrieveAbuseTicketsV2(AbuseTicketRetrieve request)
        {
            var response = await httpClient.GetAsync($"../v2/abuse/tickets{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<AbuseTicketListResponse>(JsonSettings);
        }

        /// <summary>
        /// Return the abuse ticket data for a given ticket id (v2)
        /// </summary>
        /// <param name="ticketId"></param>
        /// <returns></returns>
        public async Task<AbuseTicketV2Response> RetrieveAbuseTicketDetailV2(string ticketId)
        {
            var response = await httpClient.GetAsync($"../v2/abuse/tickets/{ticketId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<AbuseTicketV2Response>(JsonSettings);
        }
    }
}
