using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CloudDataCenterRetrieve
    {
        public string name { get; set; }
        public string status { get; set; }
        public string limit { get; set; }
        public string offset { get; set; }
    }
}
