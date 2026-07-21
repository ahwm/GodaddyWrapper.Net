using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GodaddyWrapper.Requests
{
    /// <summary>
    /// Consent record accompanying a v3 domain registration, capturing which legal agreements
    /// were accepted and when.
    /// </summary>
    public class RegistrationConsent
    {
        /// <summary>
        /// The agreement types the registrant has agreed to (from the quote's <c>requiredAgreements</c>).
        /// </summary>
        [Required]
        public List<string> AgreementTypes { get; set; }

        /// <summary>
        /// The UTC timestamp at which the agreements were accepted.
        /// </summary>
        [Required]
        public DateTime AgreedAt { get; set; }
    }
}
