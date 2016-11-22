using GodaddyWrapper.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class DomainTransferIn
    {
        [Required]
        public string authCode { get; set; }
        [Range(1, 10)]
        public int? period { get; set; }
        public bool? renewAuto { get; set; }
        public bool? privacy { get; set; }
        public Consent consent{ get; set; }
    }
}
