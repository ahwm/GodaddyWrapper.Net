using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class LineItemResponse
    {
        public string Label { get; set; }
        public int? Pfid { get; set; }
        public int Quantity { get; set; }
        public double? Period { get; set; }
        public string PeriodUnit { get; set; }
        public LineItemPricingResponse Pricing { get; set; }
        public List<string> Domains { get; set; }
    }
}
