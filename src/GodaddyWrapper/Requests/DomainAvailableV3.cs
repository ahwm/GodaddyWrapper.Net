using GodaddyWrapper.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GodaddyWrapper.Requests
{
    /// <summary>
    /// Query for the Domains v3 <c>check-availability</c> endpoint.
    /// </summary>
    public class DomainAvailableV3
    {
        /// <summary>
        /// The domain name to check (e.g. <c>example.com</c>).
        /// </summary>
        [Required]
        public string Domain { get; set; }

        /// <summary>
        /// Optionally bias the check toward <c>SPEED</c> or <c>ACCURACY</c>.
        /// </summary>
        [QueryStringToUpper]
        public string OptimizeFor { get; set; }

        /// <summary>
        /// Optional ISC (registrar) code.
        /// </summary>
        public string IscCode { get; set; }
    }
}
