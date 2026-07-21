using System;
using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    /// <summary>
    /// Domain details from GET <c>v3/domains/domain-names/{domain-name}</c>.
    /// </summary>
    public class DomainDetailV3Response
    {
        /// <summary>
        /// The domain name.
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// The IDN/unicode form of the domain, when applicable.
        /// </summary>
        public string IdnDomain { get; set; }

        /// <summary>
        /// The domain status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// When the registration expires.
        /// </summary>
        public DateTime? ExpiresAt { get; set; }

        /// <summary>
        /// When the domain was created.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// The last date the domain can be renewed.
        /// </summary>
        public DateTime? RenewBy { get; set; }

        /// <summary>
        /// When the domain was last updated.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Whether auto-renew is enabled.
        /// </summary>
        public bool AutoRenew { get; set; }

        /// <summary>
        /// Whether privacy is enabled.
        /// </summary>
        public bool Privacy { get; set; }

        /// <summary>
        /// Whether the domain is transfer-locked.
        /// </summary>
        public bool TransferLock { get; set; }

        /// <summary>
        /// The domain's nameservers.
        /// </summary>
        public List<string> NameServers { get; set; }

        /// <summary>
        /// Related links.
        /// </summary>
        public List<LinkResponse> Links { get; set; }
    }
}
