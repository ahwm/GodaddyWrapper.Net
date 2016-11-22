using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class DomainPurchase
    {
        [RegularExpression(@"^[^.]{1,63}.[^.]{2,}$")]
        public string domain { get; set; }
        public Consent consent { get; set; }
        [Range(1,10)]
        public int? period { get; set; }
        public List<string> nameServers { get; set; }
        public bool renewAuto { get; set; }
        public bool privacy { get; set; }
        public Contact contactRegistrant { get; set; }
        public Contact contactAdmin { get; set; }
        public Contact contactTech { get; set; }
        public Contact contactBilling { get; set; }
    }
}
