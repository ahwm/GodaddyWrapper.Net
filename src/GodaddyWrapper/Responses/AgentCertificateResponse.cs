using System;

namespace GodaddyWrapper.Responses
{
    public class AgentCertificateResponse
    {
        public string CsrId { get; set; }
        public string CertificatePEM { get; set; }
        public DateTime CertificateValidFrom { get; set; }
        public DateTime CertificateValidTo { get; set; }
        public string CertificateIssuer { get; set; }
        public string CertificateSubject { get; set; }
        public string CertificateSerialNumber { get; set; }
        public string CertificateSignatureAlgorithm { get; set; }
        public string CertificatePublicKeyAlgorithm { get; set; }
    }
}
