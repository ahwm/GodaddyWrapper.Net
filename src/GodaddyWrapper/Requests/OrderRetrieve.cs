using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class OrderRetrieve
    {
        [RegularExpression("^[0-9]{4}-(?:0[0-9]{1}|1[0-2]{1})-[0-9]{2}T[0-9]{2}:[0-9]{2}:[0-9]{2}Z$")]
        public string PeriodStart { get; set; }

        [RegularExpression("^[0-9]{4}-(?:0[0-9]{1}|1[0-2]{1})-[0-9]{2}T[0-9]{2}:[0-9]{2}:[0-9]{2}Z$")]
        public string PeriodEnd { get; set; }

        public string Domain { get; set; }
        public int ProductGroupId { get; set; }
        public int PaymentProfileId { get; set; }
        public string ParentOrderId { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
        public string Sort { get; set; }
    }
}
