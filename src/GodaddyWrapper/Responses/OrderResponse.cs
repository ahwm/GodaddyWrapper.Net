using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class OrderResponse
    {
        public string OrderId { get; set; }
        public string ParentOrderId { get; set; }
        public string Currency { get; set; }
        public string CreatedAt { get; set; }
        public OrderPricingResponse Pricing { get; set; }
        public BillToResponse BillTo { get; set; }
        public List<PaymentResponse> Payments { get; set; }
        public List<LineItemResponse> Items { get; set; }
    }
}
