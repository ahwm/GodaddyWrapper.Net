using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class DomainAvailableBulkResponse
    {
        public List<DomainAvailableResponse> Domains { get; set; }
    }
}
