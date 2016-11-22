using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class CountrySummaryResponse
    {
        public string CountryKey { get; set; }
        public string Label { get; set; }
        public string CallingCode { get; set; }
    }
}
