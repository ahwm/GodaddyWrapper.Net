using System;
using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    /// <summary>
    /// Result of POST <c>v3/domains/registrations</c> and GET
    /// <c>v3/domains/registrations/{registrationId}</c>.
    /// </summary>
    public class DomainRegistrationResponse
    {
        /// <summary>
        /// Identifier of the registration.
        /// </summary>
        public string RegistrationId { get; set; }

        /// <summary>
        /// The domain being registered.
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// The registration term in years.
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// The price charged.
        /// </summary>
        public SimpleMoneyResponse Price { get; set; }

        /// <summary>
        /// The consent captured for this registration.
        /// </summary>
        public ConsentResponse Consent { get; set; }

        /// <summary>
        /// The registration status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The async operation tracking this registration.
        /// </summary>
        public string OperationId { get; set; }

        /// <summary>
        /// When the registration was created.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// When the registration was last updated.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Related links (including <c>self</c>).
        /// </summary>
        public List<LinkResponse> Links { get; set; }
    }
}
