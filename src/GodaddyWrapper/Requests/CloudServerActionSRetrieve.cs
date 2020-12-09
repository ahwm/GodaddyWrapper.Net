using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CloudServerActionsRetrieve
    {
        public string Type { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
    }
}
