using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class CartGroupItemResponse
    {
        public int ItemId { get; set; }
        public int Pfid { get; set; }
        public int ProductTypeId { get; set; }
        public int Label { get; set; }
        public bool? CanRemoveAlone { get; set; }
        public int? SubscriptionId { get; set; }
        public int? Quantity { get; set; }
    
        public string QuantityUnitLabelKey { get; set; }
        public double? Period { get; set; }
        public string PeriodUnit { get; set; }
        public DateTime BillOn { get; set; }
        public CartItemTrackingResponse Tracking { get; set; }
        public CartItemCouponResponse Coupon { get; set; }
        public CartItemPricingResponse Pricing { get; set; }
        public int DisplayOrder { get; set; }
        public object Metadata { get; set; }
        public TamperSignatureResponse Signature { get; set; }


    }
}
