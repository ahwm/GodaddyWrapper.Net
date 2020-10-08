using GodaddyWrapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CertificateAddress
    {
        public string Address1 { get; set; }
        public string PostalCode { get; set; }
        [QueryStringToUpper]
        public string Country { get; set; }
        public string Address2 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
