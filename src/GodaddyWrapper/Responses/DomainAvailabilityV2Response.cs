namespace GodaddyWrapper.Responses
{
    /// <summary>
    /// Domain availability response for API v2
    /// </summary>
    public class DomainAvailabilityV2Response
    {
        /// <summary>
        /// Whether the domain is available
        /// </summary>
        public bool Available { get; set; }

        /// <summary>
        /// Domain name
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Indicates if domain is available for purchase
        /// </summary>
        public bool Definitive { get; set; }

        /// <summary>
        /// Price in micros (1/1,000,000 of currency unit)
        /// </summary>
        public long? Price { get; set; }

        /// <summary>
        /// Currency code (e.g., "USD")
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Registration period in years
        /// </summary>
        public int? Period { get; set; }
    }
}
