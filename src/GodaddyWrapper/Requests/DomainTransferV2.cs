using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GodaddyWrapper.Requests
{
    /// <summary>
    /// Domain transfer request for API v2
    /// </summary>
    public class DomainTransferV2
    {
        /// <summary>
        /// Domain name to transfer
        /// </summary>
        [Required]
        public string Domain { get; set; }

        /// <summary>
        /// Authorization code (EPP code) for the transfer
        /// </summary>
        [Required]
        public string AuthCode { get; set; }

        /// <summary>
        /// Consent to agreements
        /// </summary>
        [Required]
        public DomainPurchaseConsent Consent { get; set; }

        /// <summary>
        /// Number of years to extend the registration
        /// </summary>
        public int Period { get; set; } = 1;

        /// <summary>
        /// Contact information
        /// </summary>
        public DomainPurchaseContactsV2 ContactAdmin { get; set; }

        /// <summary>
        /// Billing contact
        /// </summary>
        public DomainPurchaseContactsV2 ContactBilling { get; set; }

        /// <summary>
        /// Registrant contact
        /// </summary>
        public DomainPurchaseContactsV2 ContactRegistrant { get; set; }

        /// <summary>
        /// Technical contact
        /// </summary>
        public DomainPurchaseContactsV2 ContactTech { get; set; }

        /// <summary>
        /// Whether to enable privacy protection
        /// </summary>
        public bool? Privacy { get; set; }

        /// <summary>
        /// Whether to enable auto-renewal
        /// </summary>
        public bool? RenewAuto { get; set; }
    }
}
