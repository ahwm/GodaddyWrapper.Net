using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class DiscountDetailResponse
    {
        public List<DiscountDetailItemResponse> Servers { get; set; }
        public List<DiscountDetailItemResponse> Addresses { get; set; }
    }
}
