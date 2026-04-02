using System.ComponentModel.DataAnnotations;

namespace GodaddyWrapper.Requests
{
    public class CertificateDownloadByEntitlementRetrieve
    {
        [Required]
        public string EntitlementId { get; set; }
    }
}
