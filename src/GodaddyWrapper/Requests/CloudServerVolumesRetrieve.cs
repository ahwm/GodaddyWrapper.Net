using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CloudServerVolumesRetrieve
    {
        public string ServerId { get; set; }
        public string ZoneId { get; set; }
        public string Status { get; set; }
        public string VolumeSpecId { get; set; }
        public string Limit { get; set; }
        public string Offset { get; set; }
    }
}
