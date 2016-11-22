using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class DomainAvailableBulkResultResponse
    {
        public bool IsFullySuccessed { get; set; }
        public DomainAvailableBulkResponse BulkDomain { get; set; }
        public DomainAvailableBulkMixedResponse BulkMixedDomain { get; set; }
    }
}
