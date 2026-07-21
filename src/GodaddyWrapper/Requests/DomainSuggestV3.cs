using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GodaddyWrapper.Requests
{
    /// <summary>
    /// Query for the Domains v3 <c>suggestions</c> endpoint.
    /// </summary>
    public class DomainSuggestV3
    {
        /// <summary>
        /// The seed keyword or domain to base suggestions on.
        /// </summary>
        [Required]
        public string Query { get; set; }

        /// <summary>
        /// Optional list of TLDs to restrict suggestions to (e.g. <c>com</c>, <c>net</c>).
        /// </summary>
        public List<string> Tlds { get; set; }

        /// <summary>
        /// Optional minimum length of the second-level domain label.
        /// </summary>
        public int? LengthMin { get; set; }

        /// <summary>
        /// Optional maximum length of the second-level domain label.
        /// </summary>
        public int? LengthMax { get; set; }

        /// <summary>
        /// Optional maximum number of suggestions to return.
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// Optional suggestion sources to draw from.
        /// </summary>
        public List<string> Sources { get; set; }
    }
}
