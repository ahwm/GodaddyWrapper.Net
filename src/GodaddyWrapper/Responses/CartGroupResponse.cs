using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class CartGroupResponse
    {
        public int GroupKey { get; set; }
        public CartGroupPricingResponse Pricing { get; set; }
        public int DisplayOrder { get; set; }
        public CartGroupItemResponse Items { get; set; }

    }
}
