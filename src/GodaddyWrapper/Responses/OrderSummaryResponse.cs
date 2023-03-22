using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class OrderSummaryResponse
    {
        public long OrderId { get; set; }
        public string ParentOrderId { get; set; }
        public string Currency { get; set; }
        public string CreatedAt { get; set; }
        public OrderSummaryPricingResponse Pricing { get; set; }
        public List<LineItemSummaryResponse> Items { get; set; }
    }
}
