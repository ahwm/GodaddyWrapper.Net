using GodaddyWrapper.Responses;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GodaddyWrapper.Requests
{
    public class AgentRegister
    {
        [Required]
        public string AgentDisplayName { get; set; }
        public string AgentDescription { get; set; }
        [Required]
        public string AgentHost { get; set; }
        [Required]
        public string Version { get; set; }
        [Required]
        public List<AgentEndpoint> Endpoints { get; set; }
        [Required]
        public string IdentityCsrPEM { get; set; }
        public string ServerCsrPEM { get; set; }
        public string ServerCertificatePEM { get; set; }
        public string ServerCertificateChainPEM { get; set; }
    }
}
