using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class TamperSignatureResponse
    {
        public string Hash { get; set; }
        public string Content { get; set; }
    }
}
