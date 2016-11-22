using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class CartPricingResponse
    {
        public int total { get; set; }
        public int subtotal { get; set; }
        public int List { get; set; }
        public int Savings { get; set; }
        public int Discount { get; set; }
        public int Taxes { get; set; }
        public CartFeeResponse Fees { get; set; }
    }
}
