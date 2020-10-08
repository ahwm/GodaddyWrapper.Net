using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CartListingAdd
    {
        public string ListingId { get; set; }
        public int? Quantity { get; set; }
        public double? PeriodCount { get; set; }
        public DateTime? BillOn { get; set; }
        public CartItemCoupon Coupon { get; set; }
        public object Metadata { get; set; }
    }
}
