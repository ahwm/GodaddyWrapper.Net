using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class DomainPurchaseResponse
    {
        public int OrderId { get; set; }
        public int ItemCount { get; set; }
        public decimal Total { get; set; }
        public string Currency { get; set; }
    }
}
