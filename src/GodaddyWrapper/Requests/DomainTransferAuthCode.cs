using System.ComponentModel.DataAnnotations;

namespace GodaddyWrapper.Requests
{
    public class DomainTransferAuthCode
    {
        [Required]
        public string AuthCode { get; set; }
    }
}
