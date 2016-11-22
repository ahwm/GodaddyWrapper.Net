using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class CloudSSHKeyResponse
    {
        public string Fingerprint { get; set; }
        public string Name { get; set; }
        public string SshKeyId { get; set; }
        public string CreatedAt { get; set; }
        public string ModifiedAt { get; set; }
    }
}
