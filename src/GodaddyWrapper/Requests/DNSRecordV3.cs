using GodaddyWrapper.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GodaddyWrapper.Requests
{
    /// <summary>
    /// A DNS record for the Domains v3 zone-based DNS endpoints
    /// (<c>v3/domains/zones/{zone}/dns-records</c>).
    /// </summary>
    public class DNSRecordV3
    {
        /// <summary>
        /// Record name relative to the zone (e.g. <c>@</c>, <c>www</c>).
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Record type (A, AAAA, CNAME, MX, TXT, SRV, NS, SOA, CAA, ...).
        /// </summary>
        [Required]
        [DNSRecordType]
        public string Type { get; set; }

        /// <summary>
        /// Record data / value.
        /// </summary>
        [Required]
        public string Data { get; set; }

        /// <summary>
        /// Time to live in seconds (600-86400).
        /// </summary>
        [Range(600, 86400)]
        public int? Ttl { get; set; }

        /// <summary>
        /// Priority (MX/SRV), 0-65535.
        /// </summary>
        [Range(0, 65535)]
        public int? Priority { get; set; }

        /// <summary>
        /// Service label (SRV records).
        /// </summary>
        public string Service { get; set; }

        /// <summary>
        /// Port (SRV records), 0-65535.
        /// </summary>
        [Range(0, 65535)]
        public int? Port { get; set; }

        /// <summary>
        /// Weight (SRV records), 0-65535.
        /// </summary>
        [Range(0, 65535)]
        public int? Weight { get; set; }

        /// <summary>
        /// Protocol label (SRV records).
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// Flag (CAA records), 0-255.
        /// </summary>
        [Range(0, 255)]
        public int? Flag { get; set; }

        /// <summary>
        /// Tag (CAA records).
        /// </summary>
        public string Tag { get; set; }
    }
}
