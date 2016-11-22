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
        public string currency { get; set; }
        public string market { get; set; }
    }
}
