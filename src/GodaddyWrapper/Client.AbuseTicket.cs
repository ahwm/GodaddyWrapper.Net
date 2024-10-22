using GodaddyWrapper.Helper;
using GodaddyWrapper.Requests;
using GodaddyWrapper.Responses;
using Newtonsoft.Json;
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
            var response = await httpClient.PostAsync($"abuse/tickets", JsonConvert.SerializeObject(request, JsonSettings));
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<AbuseTicketIdResponse>();
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
            return await response.Content.ReadAsAsync<AbuseTicketListResponse>();
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
            return await response.Content.ReadAsAsync<AbuseTicketResponse>();
        }
    }
}
