using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class CartItemUnitPricingRangeResponse
    {
        public int PeriodMin { get; set; }
        public int? PeriodMax { get; set; }
        public int Subtotal { get; set; }
    }
}
