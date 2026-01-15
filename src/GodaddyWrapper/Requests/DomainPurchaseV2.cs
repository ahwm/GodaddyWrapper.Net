using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GodaddyWrapper.Requests
{
    /// <summary>
    /// Domain purchase request for API v2
    /// </summary>
    public class DomainPurchaseV2
    {
        /// <summary>
        /// Domain name to purchase
        /// </summary>
        [Required]
        public string Domain { get; set; }

        /// <summary>
        /// Consent to agreements
        /// </summary>
        [Required]
        public DomainPurchaseConsent Consent { get; set; }

        /// <summary>
        /// Number of years to register the domain
        /// </summary>
        public int Period { get; set; } = 1;

        /// <summary>
        /// Contact information
        /// </summary>
        [Required]
        public DomainPurchaseContactsV2 ContactAdmin { get; set; }

        /// <summary>
        /// Billing contact (defaults to admin contact if not provided)
        /// </summary>
        public DomainPurchaseContactsV2 ContactBilling { get; set; }

        /// <summary>
        /// Registrant contact (defaults to admin contact if not provided)
        /// </summary>
        public DomainPurchaseContactsV2 ContactRegistrant { get; set; }

        /// <summary>
        /// Technical contact (defaults to admin contact if not provided)
        /// </summary>
        public DomainPurchaseContactsV2 ContactTech { get; set; }

        /// <summary>
        /// Name servers for the domain
        /// </summary>
        public List<string> NameServers { get; set; }

        /// <summary>
        /// Whether to enable privacy protection
        /// </summary>
        public bool? Privacy { get; set; }

        /// <summary>
        /// Whether to enable auto-renewal
        /// </summary>
        public bool? RenewAuto { get; set; }
    }

    public class DomainPurchaseConsent
    {
        [Required]
        public List<string> AgreedAt { get; set; }

        [Required]
        public string AgreedBy { get; set; }

        [Required]
        public List<string> AgreementKeys { get; set; }
    }

    public class DomainPurchaseContactsV2
    {
        [Required]
        public string NameFirst { get; set; }

        [Required]
        public string NameLast { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        public string Organization { get; set; }

        [Required]
        public AddressV2 AddressMailing { get; set; }
    }

    public class AddressV2
    {
        [Required]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string Country { get; set; }
    }
}
