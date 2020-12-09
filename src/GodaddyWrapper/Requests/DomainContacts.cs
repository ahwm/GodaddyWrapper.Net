using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class DomainContacts
    {
        public Contact ContactRegistrant { get; set; }
        public Contact ContactAdmin { get; set; }
        public Contact ContactTech { get; set; }
        public Contact ContactBilling { get; set; }
    }
}
