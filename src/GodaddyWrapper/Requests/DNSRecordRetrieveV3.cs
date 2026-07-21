namespace GodaddyWrapper.Requests
{
    /// <summary>
    /// Query for listing v3 zone DNS records
    /// (<c>GET v3/domains/zones/{zone}/dns-records</c>).
    /// </summary>
    public class DNSRecordRetrieveV3
    {
        /// <summary>
        /// 1-based page number.
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Number of records per page.
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// When true, the response includes <c>totalItems</c> / <c>totalPages</c>.
        /// </summary>
        public bool? TotalRequired { get; set; }

        /// <summary>
        /// Optional comma-separated list of fields to return.
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// Optional record type filter.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Optional record name filter.
        /// </summary>
        public string Name { get; set; }
    }
}
