using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class CertificateAddressResponse
    {
        public string address1 { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public string address2 { get; set; }
        public string state { get; set; }
        public string city { get; set; }
    }
}
