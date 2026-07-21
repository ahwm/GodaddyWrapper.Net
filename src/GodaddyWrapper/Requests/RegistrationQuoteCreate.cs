using System.ComponentModel.DataAnnotations;

namespace GodaddyWrapper.Requests
{
    /// <summary>
    /// Body for POST <c>v3/domains/registration-quotes</c>. Produces a locked price and a
    /// <c>quoteToken</c> (valid for ~10 minutes) that is then supplied to a registration.
    /// </summary>
    public class RegistrationQuoteCreate
    {
        /// <summary>
        /// The domain to quote for registration.
        /// </summary>
        [Required]
        public string Domain { get; set; }

        /// <summary>
        /// Registration term in years (1-10).
        /// </summary>
        [Range(1, 10)]
        public int? Period { get; set; }

        /// <summary>
        /// Optional identifier of a stored registration profile (contacts, privacy, nameservers, etc.).
        /// </summary>
        public string ProfileId { get; set; }
    }
}
