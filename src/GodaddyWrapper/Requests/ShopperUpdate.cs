using GodaddyWrapper.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class ShopperUpdate
    {
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public string Email { get; set; }
        public int ExternalId { get; set; }
        public string MarketId { get; set; }
    }
}
