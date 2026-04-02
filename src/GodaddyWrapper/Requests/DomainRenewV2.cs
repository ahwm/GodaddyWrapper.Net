using System.ComponentModel.DataAnnotations;

namespace GodaddyWrapper.Requests
{
    public class DomainRenewV2
    {
        [Required]
        public string Expires { get; set; }
        [Required]
        public ConsentRenew Consent { get; set; }
        public int? Period { get; set; }
    }
}
