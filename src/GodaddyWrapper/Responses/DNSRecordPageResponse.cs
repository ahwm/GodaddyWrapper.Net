using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    /// <summary>
    /// Paged envelope returned by GET <c>v3/domains/zones/{zone}/dns-records</c>.
    /// </summary>
    public class DNSRecordPageResponse
    {
        /// <summary>
        /// The records on this page.
        /// </summary>
        public List<DNSRecordResponseV3> Items { get; set; }

        /// <summary>
        /// Total records across all pages (present only when <c>totalRequired=true</c>).
        /// </summary>
        public int? TotalItems { get; set; }

        /// <summary>
        /// Total number of pages (present only when <c>totalRequired=true</c>).
        /// </summary>
        public int? TotalPages { get; set; }

        /// <summary>
        /// Pagination links.
        /// </summary>
        public List<LinkResponse> Links { get; set; }
    }
}
