namespace GodaddyWrapper.Responses
{
    /// <summary>
    /// A single domain suggestion returned by the v3 <c>suggestions</c> endpoint.
    /// </summary>
    public class SuggestionResponse
    {
        /// <summary>
        /// The suggested domain name.
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// The IDN/unicode form of the suggested domain, when applicable.
        /// </summary>
        public string UnicodeDomain { get; set; }

        /// <summary>
        /// The source that produced this suggestion.
        /// </summary>
        public string Source { get; set; }
    }
}
