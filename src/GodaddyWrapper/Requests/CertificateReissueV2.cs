using System.Collections.Generic;

namespace GodaddyWrapper.Requests
{
    public class CertificateReissueV2
    {
        public string Csr { get; set; }
        public bool? RevokeExistingCertificate { get; set; }
        public int? DelayExistingRevoke { get; set; }
        public List<string> ForceDomainRevetting { get; set; }
    }
}
