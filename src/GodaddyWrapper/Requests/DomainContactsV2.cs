using System.ComponentModel.DataAnnotations;

namespace GodaddyWrapper.Requests
{
    /// <summary>
    /// Domain contacts update request for API v2
    /// </summary>
    public class DomainContactsV2
    {
        /// <summary>
        /// Admin contact
        /// </summary>
        public Contact ContactAdmin { get; set; }

        /// <summary>
        /// Billing contact
        /// </summary>
        public Contact ContactBilling { get; set; }

        /// <summary>
        /// Registrant contact
        /// </summary>
        public Contact ContactRegistrant { get; set; }

        /// <summary>
        /// Technical contact
        /// </summary>
        public Contact ContactTech { get; set; }
    }
}
