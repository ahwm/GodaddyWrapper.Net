namespace GodaddyWrapper.Responses
{
    /// <summary>
    /// A legal agreement that must be accepted to register a domain, as surfaced by a v3 quote.
    /// </summary>
    public class RequiredAgreementResponse
    {
        /// <summary>
        /// The agreement type key (supplied back in the registration consent).
        /// </summary>
        public string AgreementType { get; set; }

        /// <summary>
        /// Human-readable agreement title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Link to the agreement text.
        /// </summary>
        public string Url { get; set; }
    }
}
