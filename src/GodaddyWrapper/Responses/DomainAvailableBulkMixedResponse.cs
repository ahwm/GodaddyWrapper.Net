using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    public class DomainAvailableBulkMixedResponse
    {
        public List<DomainAvailableResponse> Domains { get; set; }
        public List<DomainAvailableErrorResponse> Errors { get; set; }
    }
}
