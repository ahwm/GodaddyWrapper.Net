using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    /// <summary>
    /// Result of a Domains v3 <c>check-availability</c> call.
    /// </summary>
    public class DomainAvailableV3Response
    {
        /// <summary>
        /// The domain that was checked.
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// The IDN/unicode form of the domain, when applicable.
        /// </summary>
        public string UnicodeDomain { get; set; }

        /// <summary>
        /// Whether the domain is available for registration.
        /// </summary>
        public bool Available { get; set; }

        /// <summary>
        /// Whether the availability result is definitive.
        /// </summary>
        public bool Definitive { get; set; }

        /// <summary>
        /// Inventory classification for the domain.
        /// </summary>
        public string Inventory { get; set; }

        /// <summary>
        /// Indicative pricing per term.
        /// </summary>
        public List<TermPriceResponse> Prices { get; set; }

        /// <summary>
        /// Populated when the availability check errored.
        /// </summary>
        public DomainV3ErrorResponse Error { get; set; }
    }
}
