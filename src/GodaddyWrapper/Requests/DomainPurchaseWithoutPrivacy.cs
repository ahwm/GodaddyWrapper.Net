using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class DomainPurchaseWithoutPrivacy
    {
        /// <summary>
        /// For internationalized domain names with non-ascii characters, the domain name is converted to punycode before format and pattern validation rules are checked
        /// </summary>
        [RegularExpression(@"^[^.]{1,63}.[^.]{2,}$")]
        public string Domain { get; set; }

        public Consent Consent { get; set; }

        [Range(1, 10)]
        public int? Period { get; set; } = 1;

        public List<string> NameServers { get; set; }

        public bool RenewAuto { get; set; }

        public Contact ContactRegistrant { get; set; }

        public Contact ContactAdmin { get; set; }

        public Contact ContactTech { get; set; }

        public Contact ContactBilling { get; set; }
    }
}
