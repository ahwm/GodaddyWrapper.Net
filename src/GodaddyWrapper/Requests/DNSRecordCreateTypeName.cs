using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class DNSRecordCreateTypeName
    {
        [Required]
        public string data { get; set; }
        [Range(0, int.MaxValue)]
        public int? priority { get; set; }
        [Range(0, int.MaxValue)]
        public int? ttl { get; set; }
        public string service { get; set; }
        public string protocol { get; set; }
        [Range(1, 65535)]
        public int? port { get; set; }
        [Range(0, int.MaxValue)]
        public int? weight { get; set; }
    }
}
