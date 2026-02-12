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
        /// Create a new abuse ticket (v1)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AbuseTicketIdResponse> CreateAbuseTicket(AbuseTicketCreate request)
        {
            var response = await httpClient.PostAsJsonAsync($"{V1_BASE}abuse/tickets", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<AbuseTicketIdResponse>(JsonSettings);
        }

        /// <summary>
        /// Create a new abuse ticket (v2)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AbuseTicketIdResponse> CreateAbuseTicketV2(AbuseTicketCreate request)
        {
            var response = await httpClient.PostAsJsonAsync($"{V2_BASE}abuse/tickets", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<AbuseTicketIdResponse>(JsonSettings);
        }

        /// <summary>
        /// List all abuse tickets ids that match user provided filters (v1)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AbuseTicketListResponse> RetrieveAbuseTickets(AbuseTicketRetrieve request)
        {
            var response = await httpClient.GetAsync($"{V1_BASE}abuse/tickets{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<AbuseTicketListResponse>(JsonSettings);
        }

        /// <summary>
        /// List all abuse tickets ids that match user provided filters (v2)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AbuseTicketListResponse> RetrieveAbuseTicketsV2(AbuseTicketRetrieve request)
        {
            var response = await httpClient.GetAsync($"{V2_BASE}abuse/tickets{QueryStringBuilder.RequestObjectToQueryString(request)}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<AbuseTicketListResponse>(JsonSettings);
        }

        /// <summary>
        /// Return the abuse ticket data for a given ticket id (v1)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AbuseTicketResponse> RetrieveAbuseTicketDetail(AbuseTicketDetailRetrieve request)
        {
            var response = await httpClient.GetAsync($"{V1_BASE}abuse/tickets/{request.TicketId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<AbuseTicketResponse>(JsonSettings);
        }

        /// <summary>
        /// Return the abuse ticket data for a given ticket id (v2)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AbuseTicketResponse> RetrieveAbuseTicketDetailV2(AbuseTicketDetailRetrieve request)
        {
            var response = await httpClient.GetAsync($"{V2_BASE}abuse/tickets/{request.TicketId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<AbuseTicketResponse>(JsonSettings);
        }
    }
}
