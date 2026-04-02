using System.ComponentModel.DataAnnotations;

namespace GodaddyWrapper.Requests
{
    public class AgentRevoke
    {
        [Required]
        public string Reason { get; set; }
        public string Comments { get; set; }
    }
}
