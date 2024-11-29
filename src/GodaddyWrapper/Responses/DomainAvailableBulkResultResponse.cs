namespace GodaddyWrapper.Responses
{
    public class DomainAvailableBulkResultResponse
    {
        public bool IsFullySuccessed { get; set; }
        public DomainAvailableBulkResponse BulkDomain { get; set; }
        public DomainAvailableBulkMixedResponse BulkMixedDomain { get; set; }
    }
}
