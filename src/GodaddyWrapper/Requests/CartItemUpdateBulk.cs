using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CartItemUpdateBulk
    {
        public int? ItemId { get; set; }
        public int? Pfid { get; set; }
        public int? SubscriptionId { get; set; }
        public int? Quantity { get; set; }
        public int? PeriodCount { get; set; }
        public DateTime? BillOn { get; set; }
        public CartItemCoupon Coupon { get; set; }
        public object Metadata { get; set; }
        public TamperSignature Signature { get; set; }
    }
}
