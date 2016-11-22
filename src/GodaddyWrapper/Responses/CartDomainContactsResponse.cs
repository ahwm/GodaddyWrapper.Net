using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class CartDomainContactsResponse
    {
        public string ContactKey { get; set; }
        public ContactResponse Registrant { get; set; }
        public ContactResponse Admin { get; set; }
        public ContactResponse Tech { get; set; }
        public ContactResponse Billing { get; set; }
        public ContactResponse Presence { get; set; }

    }
}
