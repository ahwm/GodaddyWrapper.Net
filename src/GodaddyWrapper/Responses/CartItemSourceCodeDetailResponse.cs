using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class CartItemSourceCodeDetailResponse
    {
        public string Status { get; set; }
        public int? SpendMin { get; set; }
        public int? SpendDelta { get; set; }
        public int? Savings { get; set; }
        public double? SavingsPercent { get; set; }
    }
}
