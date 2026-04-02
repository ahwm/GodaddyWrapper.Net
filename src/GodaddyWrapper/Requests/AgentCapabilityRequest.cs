using System.ComponentModel.DataAnnotations;

namespace GodaddyWrapper.Requests
{
    public class AgentCapabilityRequest
    {
        [Required]
        public string AgentHost { get; set; }
        [Required]
        public string Version { get; set; }
    }
}
