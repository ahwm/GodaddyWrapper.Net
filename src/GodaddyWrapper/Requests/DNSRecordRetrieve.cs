using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class DNSRecordRetrieve
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int offset { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int limit { get; set; }
    }
}
