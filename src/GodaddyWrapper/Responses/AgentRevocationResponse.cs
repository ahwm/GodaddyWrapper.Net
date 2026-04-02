using GodaddyWrapper.Models;
using System;
using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    public class AgentRevocationResponse
    {
        public string AgentId { get; set; }
        public string AnsName { get; set; }
        public string Status { get; set; }
        public DateTime? RevokedAt { get; set; }
        public string Reason { get; set; }
        public List<AgentLink> Links { get; set; }
        public List<AgentDnsRecord> DnsRecordsToRemove { get; set; }
    }
}
