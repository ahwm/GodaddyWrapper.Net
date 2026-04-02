using System.ComponentModel.DataAnnotations;

namespace GodaddyWrapper.Requests
{
    public class AgentCsrSubmit
    {
        [Required]
        public string CsrPEM { get; set; }
    }
}
