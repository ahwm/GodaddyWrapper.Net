using System.ComponentModel.DataAnnotations;

namespace GodaddyWrapper.Requests
{
    public class CertificatesByEntitlementRetrieve
    {
        [Required]
        public string EntitlementId { get; set; }
        public bool? Latest { get; set; }
    }
}
