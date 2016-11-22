using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class CloudDataCenterResponse
    {
        public string Region { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string DataCenterId { get; set; }
        public string EmailRelay { get; set; }
    }
}
