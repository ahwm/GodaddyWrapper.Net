namespace GodaddyWrapper.Responses
{
    /// <summary>
    /// A DNS record returned by the Domains v3 zone endpoints.
    /// </summary>
    public class DNSRecordResponseV3
    {
        /// <summary>
        /// Server-assigned record identifier (used for deletes).
        /// </summary>
        public string RecordId { get; set; }

        /// <summary>
        /// Record name relative to the zone.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Record type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Record data / value.
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Time to live in seconds.
        /// </summary>
        public int? Ttl { get; set; }

        /// <summary>
        /// Priority (MX/SRV).
        /// </summary>
        public int? Priority { get; set; }

        /// <summary>
        /// Service label (SRV).
        /// </summary>
        public string Service { get; set; }

        /// <summary>
        /// Port (SRV).
        /// </summary>
        public int? Port { get; set; }

        /// <summary>
        /// Weight (SRV).
        /// </summary>
        public int? Weight { get; set; }

        /// <summary>
        /// Protocol label (SRV).
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// Flag (CAA).
        /// </summary>
        public int? Flag { get; set; }

        /// <summary>
        /// Tag (CAA).
        /// </summary>
        public string Tag { get; set; }
    }
}
