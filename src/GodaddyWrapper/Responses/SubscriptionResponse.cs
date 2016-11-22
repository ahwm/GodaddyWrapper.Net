using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class SubscriptionResponse
    {
        public string SubscriptionId { get; set; }
        public string Status { get; set; }
        public string Label { get; set; }
        public string LaunchUrl { get; set; }
        public SubscriptionProductResponse Product { get; set; }
        public List<SubscriptionAddonResponse> Addons { get; set; }
        public string CreatedAt { get; set; }
        public string ExpiresAt { get; set; }
        public SubscriptionBillingResponse Billing { get; set; }
        public bool Renewable { get; set; }
        public bool Upgradeable { get; set; }
        public bool Cancelable { get; set; }
        public bool PriceLocked { get; set; }
        public bool RenewAuto { get; set; }
        public int PaymentProfileId { get; set; }
        public SubscriptionRelationsResponse Relations { get; set; }


    }
}
