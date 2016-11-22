using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class CertificateResponse
    {
        public string CertificateId { get; set; }
        public string Status { get; set; }
        public string Contact { get; set; }
        public int Period { get; set; }
        public DateTime ValidStart { get; set; }
        public DateTime ValidEnd { get; set; }
        public string CommonName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string SerialNumber { get; set; }
        public string SerialNumberHex { get; set; }
        public string ProductType { get; set; }
        public DateTime RevokedAt { get; set; }
        public List<SubjectAlternativeNameDetailsResponse> SubjectAlternativeNames { get; set; }
        public string RootType { get; set; }
        public string SlotSize { get; set; }
        public string DeniedReason { get; set; }
        public int Progress { get; set; }
        public CertificateOrganizationResponse Organization { get; set; }
    }
}
