using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CloudImageRetrieve
    {
        public string DataCenterId { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string SourceServerId { get; set; }
        public string SizeMb { get; set; }
        public string Limit { get; set; }
        public string Offset { get; set; }
    }
}
