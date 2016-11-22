using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class SubscriptionBillingResponse
    {
        public string RenewAt { get; set; }
        public string Status { get; set; }
        public string Commitment { get; set; }
        public List<string> PastDueTypes { get; set; }
    }
}
