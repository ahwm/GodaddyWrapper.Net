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
        public string label { get; set; }
        public string ItemSourceCode { get; set; }
        public int? SubscriptionId { get; set; }
        public bool? Trial { get; set; }
        public int Quantity { get; set; }
        public string QuantityUnitLabelKey { get; set; }
        public double? Period { get; set; }
        public string periodUnit { get; set; }
        public DateTime? billOn { get; set; }
        public CartItemCouponResponse coupon { get; set; }
        public CartItemPricingResponse pricing { get; set; }
        public int? displayOrder { get; set; }
        public List<object> discountedItemIds { get; set; }
        public object metadata { get; set; }
        public string signature { get; set; }
    }
}
