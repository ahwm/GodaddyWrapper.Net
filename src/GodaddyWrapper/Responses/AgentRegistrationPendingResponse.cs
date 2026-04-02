using GodaddyWrapper.Models;
using System;
using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    public class AgentRegistrationPendingResponse
    {
        public string Status { get; set; }
        public string AnsName { get; set; }
        public List<AgentNextStep> NextSteps { get; set; }
        public List<AgentChallengeInfo> Challenges { get; set; }
        public List<AgentDnsRecord> DnsRecords { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public List<AgentLink> Links { get; set; }
    }
}
