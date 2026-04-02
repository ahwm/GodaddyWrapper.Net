namespace GodaddyWrapper.Requests
{
    public class DomainContactsCreateV2
    {
        public ContactDomainCreate Registrant { get; set; }
        public string RegistrantId { get; set; }
        public ContactDomainCreate Admin { get; set; }
        public string AdminId { get; set; }
        public ContactDomainCreate Tech { get; set; }
        public string TechId { get; set; }
        public ContactDomainCreate Billing { get; set; }
        public string BillingId { get; set; }
    }
}
