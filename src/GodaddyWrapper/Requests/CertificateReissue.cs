using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CertificateReissue
    {
        public string Csr { get; set; }
        public List<string> SubjectAlternativeNames { get; set; }
        public string RootType { get; set; }
        public string CallbackUrl { get; set; }
        public string CommonName { get; set; }
        [Range(0, 168)]
        public int? DelayExistingRevoke { get; set; }

    }
}
