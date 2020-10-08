using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CartItemTracking
    {
        public string ClientIp { get; set; }
        public string ItemTrackingCode { get; set; }
        public string Pathway { get; set; }
        public CartAffiliate Affiliate { get; set; }
    }
}
