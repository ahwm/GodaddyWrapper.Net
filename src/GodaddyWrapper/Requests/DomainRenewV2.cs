using System.ComponentModel.DataAnnotations;

namespace GodaddyWrapper.Requests
{
    /// <summary>
    /// Domain renewal request for API v2
    /// </summary>
    public class DomainRenewV2
    {
        /// <summary>
        /// Number of years to renew
        /// </summary>
        [Required]
        public int Period { get; set; } = 1;
    }
}
