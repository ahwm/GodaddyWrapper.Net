using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CartDomainContacts
    {
        public string ContactKey { get; set; }
        public Contact Registrant { get; set; }
        public Contact Admin { get; set; }
        public Contact Tech { get; set; }
        public Contact Billing { get; set; }
        public Contact Presence { get; set; }
    }
}
