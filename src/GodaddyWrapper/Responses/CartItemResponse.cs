using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class CartItemResponse
    {
        public int ItemId { get; set; }
        public int Pfid { get; set; }
        public int ProductTypeId { get; set; }
        public CartItemTrackingResponse Tracking { get; set; }
        public string Label { get; set; }
        public string ItemSourceCode { get; set; }
        public int? SubscriptionId { get; set; }
        public bool? Trial { get; set; }
        public int Quantity { get; set; }
        public string QuantityUnitLabelKey { get; set; }
        public double? Period { get; set; }
        public string PeriodUnit { get; set; }
        public DateTime? BillOn { get; set; }
        public CartItemCouponResponse Coupon { get; set; }
        public CartItemPricingResponse Pricing { get; set; }
        public int? DisplayOrder { get; set; }
        public List<object> DiscountedItemIds { get; set; }
        public object Metadata { get; set; }
        public string Signature { get; set; }
    }
}
