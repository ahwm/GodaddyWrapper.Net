using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class CloudImageListResponse
    {
        public List<CloudImageResponse> Results { get; set; }
        public PaginationResponse Pagination { get; set; }
    }
}
