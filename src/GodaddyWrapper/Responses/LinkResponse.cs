namespace GodaddyWrapper.Responses
{
    /// <summary>
    /// A HATEOAS link descriptor returned by the Domains v3 API.
    /// </summary>
    public class LinkResponse
    {
        /// <summary>
        /// The target URL.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// The relationship of the link to the current resource (e.g. <c>self</c>).
        /// </summary>
        public string Rel { get; set; }
    }
}
