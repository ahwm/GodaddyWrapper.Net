using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CloudImageRetrieve
    {
        public string dataCenterId { get; set; }
        public string name { get; set; }
        public string version { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string sourceServerId { get; set; }
        public string sizeMb { get; set; }
        public string limit { get; set; }
        public string offset { get; set; }
    }
}
