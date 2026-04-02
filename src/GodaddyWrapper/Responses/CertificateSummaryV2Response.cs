using System;

namespace GodaddyWrapper.Responses
{
    public class CertificateSummaryV2Response
    {
        public string CertificateId { get; set; }
        public string CommonName { get; set; }
        public int? Period { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? RevokedAt { get; set; }
        public string SubscriptionId { get; set; }
    }
}
