namespace GodaddyWrapper.Requests
{
    public class AgentEventsRetrieve
    {
        public string ProviderId { get; set; }
        public string LastLogId { get; set; }
        public int? Limit { get; set; }
    }
}
