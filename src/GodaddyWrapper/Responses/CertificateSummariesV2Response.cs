using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    public class CertificateSummariesV2Response
    {
        public List<CertificateSummaryV2Response> Certificates { get; set; }
        public PaginationResponse Pagination { get; set; }
    }
}
