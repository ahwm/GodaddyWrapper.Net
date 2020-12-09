using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CloudImageActionRetrieve
    {
        public string Type { get; set; }
        public string Limit { get; set; }
        public string Offset { get; set; }
    }
}
