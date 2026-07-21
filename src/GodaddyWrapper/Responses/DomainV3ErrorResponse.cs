using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    /// <summary>
    /// Error object used across the Domains v3 API (availability errors, failed operations, etc.).
    /// </summary>
    public class DomainV3ErrorResponse
    {
        /// <summary>
        /// Machine-readable error name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Correlation identifier for support/diagnostics.
        /// </summary>
        public string CorrelationId { get; set; }

        /// <summary>
        /// Human-readable error message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Optional link to further information about the error.
        /// </summary>
        public string InformationLink { get; set; }

        /// <summary>
        /// Optional per-field / per-item error details.
        /// </summary>
        public List<ErrorDetailResponse> Details { get; set; }

        /// <summary>
        /// Optional related links.
        /// </summary>
        public List<LinkResponse> Links { get; set; }
    }
}
