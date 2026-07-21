namespace GodaddyWrapper.Responses
{
    /// <summary>
    /// A single detail entry within a Domains v3 <see cref="DomainV3ErrorResponse"/>.
    /// </summary>
    public class ErrorDetailResponse
    {
        /// <summary>
        /// Machine-readable code for this detail.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The request path or field this detail refers to.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Human-readable message for this detail.
        /// </summary>
        public string Message { get; set; }
    }
}
