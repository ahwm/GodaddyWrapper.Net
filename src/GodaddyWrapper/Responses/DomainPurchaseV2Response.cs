namespace GodaddyWrapper.Responses
{
    /// <summary>
    /// Domain purchase response for API v2
    /// </summary>
    public class DomainPurchaseV2Response
    {
        /// <summary>
        /// Order ID
        /// </summary>
        public long OrderId { get; set; }

        /// <summary>
        /// Domain ID
        /// </summary>
        public long? DomainId { get; set; }

        /// <summary>
        /// Total amount charged
        /// </summary>
        public decimal? ItemCount { get; set; }

        /// <summary>
        /// Currency code
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Total price in micros
        /// </summary>
        public long? Total { get; set; }
    }
}
