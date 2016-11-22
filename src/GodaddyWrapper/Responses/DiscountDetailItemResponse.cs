using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class DiscountDetailItemResponse
    {
        public string EstimatedDiscount { get; set; }
        public int Hours { get; set; }
        public string Description { get; set; }
        public string ItemId { get; set; }

    }
}
