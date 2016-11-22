using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class OrderPricingResponse
    {
        public int Total { get; set; }
        public int Subtotal { get; set; }
        public int List { get; set; }
        public int Savings { get; set; }
        public int Discount { get; set; }
        public int Taxes { get; set; }
        public OrderFeeResponse Fees { get; set; }
        public double id { get; set; }
    }
}
