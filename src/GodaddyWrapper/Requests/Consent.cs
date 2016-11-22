using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class Consent
    {
        public List<string> agreementKeys { get; set; }
        public string agreedBy { get; set; }
        public DateTime agreedAt { get; set; }
    }
}
