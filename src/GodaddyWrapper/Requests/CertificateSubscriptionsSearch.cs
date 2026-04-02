namespace GodaddyWrapper.Requests
{
    public class CertificateSubscriptionsSearch
    {
        public int? PageSize { get; set; }
        public int? Page { get; set; }
        public string Domain { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Validation { get; set; }
    }
}
