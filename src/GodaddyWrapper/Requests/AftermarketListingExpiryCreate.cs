using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class AftermarketListingExpiryCreate
    {
        public string domain { get; set; }
        public string expiresAt { get; set; }
        [Range(1,int.MaxValue)]
        public int losingRegistrarId { get; set; }
        public int? pageViewsMonthly { get; set; }
        public int? revenueMonthly { get; set; }
    }
}
