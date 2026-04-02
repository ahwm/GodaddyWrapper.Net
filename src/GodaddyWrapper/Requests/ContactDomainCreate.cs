namespace GodaddyWrapper.Requests
{
    public class ContactDomainCreate
    {
        public string Encoding { get; set; }
        public string NameFirst { get; set; }
        public string NameMiddle { get; set; }
        public string NameLast { get; set; }
        public string Organization { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public Address AddressMailing { get; set; }
    }
}
