namespace GodaddyWrapper.Requests
{
    public class SubscriptionCertificateCreate
    {
        public string CallbackUrl { get; set; }
        public string CommonName { get; set; }
        public string CertificateId { get; set; }
        public CertificateContact Contact { get; set; }
        public string Csr { get; set; }
        public bool? IntelVPro { get; set; }
        public CertificateOrganizationCreate Organization { get; set; }
        public int? Period { get; set; }
        public string TermType { get; set; }
        public string ProductType { get; set; }
        public string RootType { get; set; }
        public string SlotSize { get; set; }
        public string SubjectAlternativeNames { get; set; }
    }
}
