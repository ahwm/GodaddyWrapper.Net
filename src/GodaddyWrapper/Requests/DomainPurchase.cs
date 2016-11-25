using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class DomainPurchase
    {
        /// <summary>
        /// For internationalized domain names with non-ascii characters, the domain name is converted to punycode before format and pattern validation rules are checked
        /// </summary>
        [RegularExpression(@"^[^.]{1,63}.[^.]{2,}$")]
        public string domain { get; set; }
        public Consent consent { get; set; }
        [Range(1, 10)]
        public int? period { get; set; } = 1;
        public List<string> nameServers { get; set; }
        public bool renewAuto { get; set; }
        public bool privacy { get; set; }
        public Contact contactRegistrant { get; set; }
        public Contact contactAdmin { get; set; }
        public Contact contactTech { get; set; }
        public Contact contactBilling { get; set; }
    }
}
