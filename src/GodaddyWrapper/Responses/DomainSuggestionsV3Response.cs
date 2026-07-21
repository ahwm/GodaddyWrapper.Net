using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    /// <summary>
    /// Envelope returned by the v3 <c>suggestions</c> endpoint.
    /// </summary>
    public class DomainSuggestionsV3Response
    {
        /// <summary>
        /// The suggested domains.
        /// </summary>
        public List<SuggestionResponse> Items { get; set; }
    }
}
