using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CloudImageCreate
    {
        public string Version { get; set; }
        public string SourceServerId { get; set; }
        public string Name { get; set; }
        public string DataCenterId { get; set; }
        public string SourceImageId { get; set; }
    }
}
