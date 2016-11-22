using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class CloudServerListResponse
    {
        public List<CloudServerResponse> Results { get; set; }
        public PaginationResponse Pagination { get; set; }
    }
}
