using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CertificateOrganizationCreate
    {
        public string Name { get; set; }
        public CertificateAddress Address { get; set; }
        public string Phone { get; set; }
        public string AssumedName { get; set; }
        public string RegistrationNumber { get; set; }
        public string RegistrationAgent { get; set; }
    }
}
