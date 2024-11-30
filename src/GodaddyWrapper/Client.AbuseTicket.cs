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
        /// Create a new abuse ticket
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AbuseTicketIdResponse> CreateAbuseTicket(AbuseTicketCreate request)
        {
            var response = await httpClient.PostAsJsonAsync($"abuse/tickets", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<AbuseTicketIdResponse>(JsonSettings);
        }
        /// <summary>
        /// List all abuse tickets ids that match user provided filters
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AbuseTicketListResponse> RetrieveAbuseTickets(AbuseTicketRetrieve request)
        {
            var response = await httpClient.GetAsync($"abuse/tickets{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<AbuseTicketListResponse>(JsonSettings);
        }

        /// <summary>
        /// Return the abuse ticket data for a given ticket id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AbuseTicketResponse> RetrieveAbuseTicketDetail(AbuseTicketDetailRetrieve request)
        {
            var response = await httpClient.GetAsync($"abuse/tickets/{request.TicketId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<AbuseTicketResponse>(JsonSettings);
        }
    }
}
