using GodaddyWrapper.Attributes;
using System.Collections.Generic;

namespace GodaddyWrapper.Requests
{
    public class AgentSearch
    {
        public string AgentDisplayName { get; set; }
        public string Version { get; set; }
        public string AgentHost { get; set; }
        [QueryStringToUpper]
        public string Protocol { get; set; }
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public List<string> Status { get; set; }
    }
}
