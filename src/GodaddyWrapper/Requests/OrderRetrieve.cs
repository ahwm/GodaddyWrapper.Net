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
        public string periodStart { get; set; }
        [RegularExpression("^[0-9]{4}-(?:0[0-9]{1}|1[0-2]{1})-[0-9]{2}T[0-9]{2}:[0-9]{2}:[0-9]{2}Z$")]
        public string periodEnd { get; set; }
        public string domain { get; set; }
        public int productGroupId { get; set; }
        public int paymentProfileId { get; set; }
        public string parentOrderId { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public string sort { get; set; }
    }
}
