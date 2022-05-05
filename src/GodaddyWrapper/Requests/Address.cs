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
        public string Address1 { get; set; }
        [MaxLength(41)]
        public string Address2 { get; set; }
        [MinLength(1)]
        [MaxLength(30)]
        public string City { get; set; }
        [MinLength(1)]
        [MaxLength(30)]
        public string State { get; set; }
        [MinLength(1)]
        [MaxLength(10)]
        public string PostalCode { get; set; }
        [Country]
        [QueryStringToUpper]
        public string Country { get; set; }
    }
}
