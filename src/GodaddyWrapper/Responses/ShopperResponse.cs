using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class ShopperResponse
    {
        public string ShopperId { get; set; }
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public string Email { get; set; }
        public int ExternalId { get; set; }
        public string MarketId { get; set; }
    }
}
