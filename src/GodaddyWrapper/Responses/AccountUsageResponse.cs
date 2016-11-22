using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class AccountUsageResponse
    {
        public CloudServerUsageDetailResponse Servers { get; set; }
        public UsageSummaryResponse Summary { get; set; }
        public DiscountDetailResponse Discounts { get; set; }
        public AddressUsageDetailResponse Addresses { get; set; }
    }
}
