using System;
using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    /// <summary>
    /// The consent captured with a v3 registration, as echoed back by the API.
    /// </summary>
    public class ConsentResponse
    {
        /// <summary>
        /// The agreement types that were accepted.
        /// </summary>
        public List<string> AgreementTypes { get; set; }

        /// <summary>
        /// When the agreements were accepted.
        /// </summary>
        public DateTime? AgreedAt { get; set; }
    }
}
