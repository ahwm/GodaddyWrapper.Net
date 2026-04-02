using GodaddyWrapper.Models;
using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    public class AgentResolutionResponse
    {
        public string AnsName { get; set; }
        public List<AgentLink> Links { get; set; }
    }
}
