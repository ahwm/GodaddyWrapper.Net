namespace GodaddyWrapper.Responses
{
    /// <summary>
    /// Price for a specific registration term, as returned by v3 availability and quotes.
    /// </summary>
    public class TermPriceResponse
    {
        /// <summary>
        /// The term unit (e.g. <c>YEAR</c>).
        /// </summary>
        public string Term { get; set; }

        /// <summary>
        /// Number of terms (1-10).
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// The price for this term.
        /// </summary>
        public SimpleMoneyResponse Price { get; set; }

        /// <summary>
        /// The renewal price for this term, when provided.
        /// </summary>
        public SimpleMoneyResponse RenewalPrice { get; set; }
    }
}
