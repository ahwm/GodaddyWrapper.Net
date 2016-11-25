using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class Consent
    {
        /// <summary>
        /// Unique identifiers of the legal agreements to which the end-user has agreed, as returned from the/domains/agreements endpoint
        /// </summary>
        public List<string> agreementKeys { get; set; }
        /// <summary>
        /// Originating client IP address of the end-user's computer when they consented to these legal agreements
        /// </summary>
        public string agreedBy { get; set; }
        /// <summary>
        /// Timestamp indicating when the end-user consented to these legal agreements
        /// </summary>
        public DateTime agreedAt { get; set; }
    }
}
