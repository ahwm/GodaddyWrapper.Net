namespace GodaddyWrapper.Requests
{
    public class DomainContactsUpdateV2
    {
        public string IdentityDocumentId { get; set; }
        public DomainContactsCreateV2 Contacts { get; set; }
    }
}
