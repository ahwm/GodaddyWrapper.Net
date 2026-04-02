using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    public class AgentEventPageResponse
    {
        public List<AgentEventItemResponse> Items { get; set; }
        public string LastLogId { get; set; }
    }
}
