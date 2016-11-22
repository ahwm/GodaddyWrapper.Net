using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class DomainContacts
    {
        public Contact contactRegistrant { get; set; }
        public Contact contactAdmin { get; set; }
        public Contact contactTech { get; set; }
        public Contact contactBilling { get; set; }
    }
}
