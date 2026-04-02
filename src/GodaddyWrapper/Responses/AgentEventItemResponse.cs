using System;
using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    public class AgentEventItemResponse
    {
        public string LogId { get; set; }
        public string EventType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public string AgentId { get; set; }
        public string AnsName { get; set; }
        public string AgentHost { get; set; }
        public string AgentDisplayName { get; set; }
        public string AgentDescription { get; set; }
        public string Version { get; set; }
        public string ProviderId { get; set; }
        public List<AgentEndpoint> Endpoints { get; set; }
    }
}
