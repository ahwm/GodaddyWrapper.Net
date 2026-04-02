using System.Collections.Generic;

namespace GodaddyWrapper.Models
{
    public class AgentEndpoint
    {
        public string AgentUrl { get; set; }
        public string MetaDataUrl { get; set; }
        public string DocumentationUrl { get; set; }
        public string Protocol { get; set; }
        public List<string> Transports { get; set; }
        public List<AgentFunction> Functions { get; set; }
    }
}
