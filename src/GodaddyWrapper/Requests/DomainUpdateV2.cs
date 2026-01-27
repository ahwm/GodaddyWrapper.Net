using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GodaddyWrapper.Requests
{
    /// <summary>
    /// Domain update request for API v2
    /// </summary>
    public class DomainUpdateV2
    {
        /// <summary>
        /// Whether or not the domain is locked to prevent transfers
        /// </summary>
        public bool? Locked { get; set; }

        /// <summary>
        /// Name servers for the domain
        /// </summary>
        public List<string> NameServers { get; set; }

        /// <summary>
        /// Whether or not the domain should be renewed automatically
        /// </summary>
        public bool? RenewAuto { get; set; }

        /// <summary>
        /// Subaccount ID
        /// </summary>
        public string SubaccountId { get; set; }

        /// <summary>
        /// Whether or not privacy protection is enabled
        /// </summary>
        public bool? PrivacyEnabled { get; set; }
    }
}
