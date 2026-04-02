namespace GodaddyWrapper.Responses
{
    public class DomainVerificationDetailResponse : DomainVerificationSummaryResponse
    {
        public CertificateAuthorityAuthorizationResponse CertificateAuthorityAuthorization { get; set; }
    }

    public class CertificateAuthorityAuthorizationResponse
    {
        public string Status { get; set; }
    }
}
