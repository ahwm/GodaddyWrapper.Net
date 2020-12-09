using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CloudUsageRetrieve
    {
        [RegularExpression("^[A-Z][A-Z][A-Z]$")]
        public string Currency { get; set; }
        public string Market { get; set; }
    }
}
