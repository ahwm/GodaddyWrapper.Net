namespace GodaddyWrapper.Responses
{
    public class DomainForwardingResponse
    {
        public string Fqdn { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public DomainForwardingMaskResponse Mask { get; set; }
    }

    public class DomainForwardingMaskResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
    }
}
