using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    /// <summary>
    /// Domain list response for API v2
    /// </summary>
    public class DomainListV2Response
    {
        /// <summary>
        /// List of domains
        /// </summary>
        public List<DomainSummaryV2Response> Domains { get; set; }

        /// <summary>
        /// Pagination marker for next page
        /// </summary>
        public string Marker { get; set; }
    }

    /// <summary>
    /// Domain summary information for API v2
    /// </summary>
    public class DomainSummaryV2Response
    {
        /// <summary>
        /// Domain ID
        /// </summary>
        public long DomainId { get; set; }

        /// <summary>
        /// Domain name
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Domain status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Expiration date
        /// </summary>
        public string Expires { get; set; }

        /// <summary>
        /// Whether the domain is locked
        /// </summary>
        public bool Locked { get; set; }

        /// <summary>
        /// Whether privacy is enabled
        /// </summary>
        public bool Privacy { get; set; }

        /// <summary>
        /// Whether auto-renewal is enabled
        /// </summary>
        public bool RenewAuto { get; set; }

        /// <summary>
        /// Creation date
        /// </summary>
        public string CreatedAt { get; set; }
    }
}
