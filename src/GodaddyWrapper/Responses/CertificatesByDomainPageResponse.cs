using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    public class CertificatesByDomainPageResponse
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
        public List<CertificatesByDomainPagedResponse> Data { get; set; }
    }
}
