using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CloudAddressRetrieve
    {
        public string Address { get; set; }
        public string ServerId { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Limit { get; set; }
        public string Offset { get; set; }
    }
}
