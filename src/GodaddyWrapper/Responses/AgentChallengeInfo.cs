using System;

namespace GodaddyWrapper.Responses
{
    public class AgentChallengeInfo
    {
        public string Token { get; set; }
        public string KeyAuthorization { get; set; }
        public string Type { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public AgentChallengeInfoDnsRecord DnsRecord { get; set; }
        public string HttpPath { get; set; }
    }

    public class AgentChallengeInfoDnsRecord
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
