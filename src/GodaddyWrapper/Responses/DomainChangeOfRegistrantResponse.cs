using System;

namespace GodaddyWrapper.Responses
{
    public class DomainChangeOfRegistrantResponse
    {
        public DateTime? CreateDate { get; set; }
        public ContactRegistrantChangeResponse GainingContact { get; set; }
        public ContactRegistrantChangeResponse LosingContact { get; set; }
        public int? OtherDomainsAffected { get; set; }
        public string ShopperEmail { get; set; }
    }

    public class ContactRegistrantChangeResponse
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Organization { get; set; }
    }
}
