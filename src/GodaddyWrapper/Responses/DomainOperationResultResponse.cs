namespace GodaddyWrapper.Responses
{
    /// <summary>
    /// Terminal result payload of a completed Domains v3 operation. Fields vary by operation
    /// type; the commonly present values are surfaced here.
    /// </summary>
    public class DomainOperationResultResponse
    {
        /// <summary>
        /// The domain the operation acted on.
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// The resulting status, when provided.
        /// </summary>
        public string Status { get; set; }
    }
}
