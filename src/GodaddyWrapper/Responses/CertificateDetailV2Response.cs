using System;
using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    public class CertificateDetailV2Response
    {
        public string CertificateId { get; set; }
        public string CommonName { get; set; }
        public int? Period { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public List<string> SubjectAlternativeNames { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ValidStart { get; set; }
        public DateTime? ValidEnd { get; set; }
        public DateTime? RevokedAt { get; set; }
        public string SubscriptionId { get; set; }
        public string SerialNumber { get; set; }
        public string Organization { get; set; }
    }
}
