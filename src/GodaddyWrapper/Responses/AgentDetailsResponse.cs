using GodaddyWrapper.Models;
using System;
using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    public class AgentDetailsResponse
    {
        public string AgentId { get; set; }
        public string AnsName { get; set; }
        public string AgentDisplayName { get; set; }
        public string AgentDescription { get; set; }
        public string AgentHost { get; set; }
        public string Version { get; set; }
        public string AgentStatus { get; set; }
        public List<AgentEndpoint> Endpoints { get; set; }
        public List<AgentLink> Links { get; set; }
        public DateTime? RegistrationTimestamp { get; set; }
        public DateTime? LastRenewalTimestamp { get; set; }
        public AgentRegistrationPendingResponse RegistrationPending { get; set; }
    }
}
