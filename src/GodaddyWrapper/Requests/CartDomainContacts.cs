using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CartDomainContacts
    {
        public string contactKey { get; set; }
        public Contact registrant { get; set; }
        public Contact admin { get; set; }
        public Contact tech { get; set; }
        public Contact billing { get; set; }
        public Contact presence { get; set; }
    }
}
