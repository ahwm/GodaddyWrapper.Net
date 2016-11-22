using GodaddyWrapper.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class Address
    {
        [MinLength(1)]
        [MaxLength(41)]
        public string address1 { get; set; }
        [MaxLength(41)]
        public string address2 { get; set; }
        [MinLength(1)]
        [MaxLength(30)]
        public string city { get; set; }
        [MinLength(1)]
        [MaxLength(30)]
        public string state { get; set; }
        [MinLength(1)]
        [MaxLength(10)]
        public string postalCode { get; set; }
        [CountryAttribtue]
        public string country { get; set; }
    }
}
