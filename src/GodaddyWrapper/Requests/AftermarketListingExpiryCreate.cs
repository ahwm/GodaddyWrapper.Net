using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class AftermarketListingExpiryCreate
    {
        public string Domain { get; set; }
        public string ExpiresAt { get; set; }
        [Range(1,int.MaxValue)]
        public int LosingRegistrarId { get; set; }
        public int? PageViewsMonthly { get; set; }
        public int? RevenueMonthly { get; set; }
    }
}
