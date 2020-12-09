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
        public string AuthCode { get; set; }

        [Range(1, 10)]
        public int? Period { get; set; }

        public bool? RenewAuto { get; set; }

        public bool? Privacy { get; set; }

        public Consent Consent{ get; set; }
    }
}
