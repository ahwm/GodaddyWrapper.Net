using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CloudIpAddressCreate
    {
        public string dataCenterId { get; set; }
        public string zoneId { get; set; }
    }
}
