using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    /// <summary>
    /// Result of POST <c>v3/domains/registration-quotes</c>.
    /// </summary>
    public class RegistrationQuoteResponse
    {
        /// <summary>
        /// The quoted domain.
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Whether the domain is available for registration.
        /// </summary>
        public bool Available { get; set; }

        /// <summary>
        /// The token to supply to a registration; absent when the domain is unavailable.
        /// Valid for approximately 10 minutes.
        /// </summary>
        public string QuoteToken { get; set; }

        /// <summary>
        /// The quoted registration term in years.
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// The locked price for the quoted term.
        /// </summary>
        public SimpleMoneyResponse Price { get; set; }

        /// <summary>
        /// Agreements that must be accepted to complete registration.
        /// </summary>
        public List<RequiredAgreementResponse> RequiredAgreements { get; set; }

        /// <summary>
        /// Settings resolved for the registration.
        /// </summary>
        public ResolvedSettingsResponse ResolvedSettings { get; set; }
    }
}
