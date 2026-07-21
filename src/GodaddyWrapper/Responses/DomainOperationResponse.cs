using System;
using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    /// <summary>
    /// An asynchronous Domains v3 operation (registration, renewal, transfer, nameserver update, ...),
    /// returned by write endpoints (202) and by GET <c>v3/domains/operations/{operationId}</c>.
    /// </summary>
    public class DomainOperationResponse
    {
        /// <summary>
        /// The operation identifier.
        /// </summary>
        public string OperationId { get; set; }

        /// <summary>
        /// The operation type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The domain the operation acts on.
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// The operation status: <c>CONFIRMED</c>, <c>EXECUTING</c>, <c>COMPLETED</c>, or <c>FAILED</c>.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The result payload; present only when the operation has <c>COMPLETED</c>.
        /// </summary>
        public DomainOperationResultResponse Result { get; set; }

        /// <summary>
        /// The error; present only when the operation has <c>FAILED</c>.
        /// </summary>
        public DomainV3ErrorResponse Error { get; set; }

        /// <summary>
        /// When the operation was created.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// When the operation was last updated.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Related links (including <c>self</c>).
        /// </summary>
        public List<LinkResponse> Links { get; set; }
    }
}
