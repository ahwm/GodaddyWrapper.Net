using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class CertificateOrganizationResponse
    {
        public string name { get; set; }
        public CertificateAddressResponse address { get; set; }
        public string Phone { get; set; }
        public string AssumedName { get; set; }
        public string RegistrationNumber { get; set; }
        public string RegistrationAgent { get; set; }
        public JurisdictionOfIncorporationResponse JurisdictionOfIncorporation { get; set; }

    }
}
