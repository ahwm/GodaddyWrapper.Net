namespace GodaddyWrapper.Responses
{
    /// <summary>
    /// Domain transfer response for API v2
    /// </summary>
    public class DomainTransferV2Response
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
        /// Transfer status
        /// </summary>
        public string Status { get; set; }

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
