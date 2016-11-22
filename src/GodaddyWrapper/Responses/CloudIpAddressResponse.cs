using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class CloudIpAddressResponse
    {
        public string Status { get; set; }
        public string Version { get; set; }
        public string ZoneId { get; set; }
        public string CreatedAt { get; set; }
        public string Address { get; set; }
        public string AddressId { get; set; }
        public string Type { get; set; }
        public string DataCenterId { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ServerId { get; set; }
    }
}
