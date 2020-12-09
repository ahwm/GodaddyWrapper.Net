using GodaddyWrapper.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class SubaccountCreate
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public int ExternalId { get; set; }
        public string MarketId { get; set; }
    }
}
