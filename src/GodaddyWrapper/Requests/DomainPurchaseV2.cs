using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GodaddyWrapper.Requests
{
    public class DomainPurchaseV2
    {
        [Required]
        public string Domain { get; set; }
        public ConsentV2 Consent { get; set; }
        public int? Period { get; set; }
        public List<string> NameServers { get; set; }
        public bool? RenewAuto { get; set; }
        public bool? Privacy { get; set; }
        public DomainContactsCreateV2 Contacts { get; set; }
    }
}
