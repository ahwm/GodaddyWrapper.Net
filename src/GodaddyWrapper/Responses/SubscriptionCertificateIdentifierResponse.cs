namespace GodaddyWrapper.Responses
{
    public class SubscriptionCertificateIdentifierResponse
    {
        public string CertificateId { get; set; }
        public string SubscriptionId { get; set; }
        public bool SubscriptionCreatedForOrder { get; set; }
    }
}
