using System.ComponentModel.DataAnnotations;

namespace GodaddyWrapper.Requests
{
    /// <summary>
    /// Body for POST <c>v3/domains/registrations</c>. Executes a previously obtained quote.
    /// </summary>
    public class DomainRegistrationCreate
    {
        /// <summary>
        /// The domain being registered (must match the quoted domain).
        /// </summary>
        [Required]
        public string Domain { get; set; }

        /// <summary>
        /// Registration term in years (must match the quoted period).
        /// </summary>
        [Range(1, 10)]
        public int? Period { get; set; }

        /// <summary>
        /// The <c>quoteToken</c> returned from the registration quote.
        /// </summary>
        [Required]
        public string QuoteToken { get; set; }

        /// <summary>
        /// Consent to the agreements required by the quote.
        /// </summary>
        [Required]
        public RegistrationConsent Consent { get; set; }
    }
}
