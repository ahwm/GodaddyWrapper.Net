using GodaddyWrapper.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class DNSRecord
    {
        [Required]
        [DNSRecordType]
        public string Type { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Data { get; set; }

        [Range(0, int.MaxValue)]
        public int? Priority { get; set; }

        [Range(0, int.MaxValue)]
        public int? Ttl { get; set; }

        public string Service { get; set; }

        public string Protocol { get; set; }

        [Range(1, 65535)]
        public int? Port { get; set; }

        [Range(0, int.MaxValue)]
        public int? Weight { get; set; }
    }
}
