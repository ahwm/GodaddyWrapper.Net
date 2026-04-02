using System.ComponentModel.DataAnnotations;

namespace GodaddyWrapper.Requests
{
    public class DomainRedeemV2
    {
        [Required]
        public ConsentRedemption Consent { get; set; }
    }
}
