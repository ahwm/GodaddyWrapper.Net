using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CloudServerActionsRetrieve
    {
        public string type { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
    }
}
