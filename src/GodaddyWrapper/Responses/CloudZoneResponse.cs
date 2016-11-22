using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class CloudZoneResponse
    {
        public string Status { get; set; }
        public string DataCenterId { get; set; }
        public string SupportsVolumes { get; set; }
        public string ZoneId { get; set; }
    }
}
