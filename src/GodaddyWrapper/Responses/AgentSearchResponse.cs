using GodaddyWrapper.Models;
using System;
using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    public class AgentSearchResponse
    {
        public List<AgentSummaryResponse> Agents { get; set; }
        public bool HasMore { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int ReturnedCount { get; set; }
        public int TotalCount { get; set; }
        public AgentSearchCriteriaResponse SearchCriteria { get; set; }
    }

    public class AgentSummaryResponse
    {
        public string AgentId { get; set; }
        public string AnsName { get; set; }
        public string AgentDisplayName { get; set; }
        public string AgentDescription { get; set; }
        public string AgentHost { get; set; }
        public string Version { get; set; }
        public List<AgentEndpoint> Endpoints { get; set; }
        public List<AgentLink> Links { get; set; }
        public DateTime? RegistrationTimestamp { get; set; }
        public int? Ttl { get; set; }
    }

    public class AgentSearchCriteriaResponse
    {
        public string AgentDisplayName { get; set; }
        public string AgentHost { get; set; }
        public string Protocol { get; set; }
        public string Version { get; set; }
    }
}
