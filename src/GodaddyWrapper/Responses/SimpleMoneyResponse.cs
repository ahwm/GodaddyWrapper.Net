namespace GodaddyWrapper.Responses
{
    /// <summary>
    /// A monetary amount as returned by the Domains v3 API.
    /// </summary>
    public class SimpleMoneyResponse
    {
        /// <summary>
        /// ISO 4217 currency code (e.g. <c>USD</c>).
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// The amount in currency micro-units (multiply by 1e-6 for the display value).
        /// </summary>
        public long Value { get; set; }
    }
}
