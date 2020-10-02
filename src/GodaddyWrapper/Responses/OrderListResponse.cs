using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class OrderListResponse
    {
        public List<OrderSummaryResponse> Orders { get; set; }
        public PaginationResponse Pagination { get; set; }
    }
}
