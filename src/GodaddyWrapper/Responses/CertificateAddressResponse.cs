using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class CertificateAddressResponse
    {
        public string Address1 { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Address2 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
