using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class DNSRecordResponse
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
        public int priority { get; set; }
        public int ttl { get; set; }
        public string service { get; set; }
        public string protocol { get; set; }
        public int port { get; set; }
        public int weight { get; set; }

    }
}
