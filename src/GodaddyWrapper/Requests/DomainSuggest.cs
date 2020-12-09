using GodaddyWrapper.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class DomainSuggest
    {
        [Required]
        public string Query { get; set; }

        [CountryAttribtue]
        [QueryStringToUpper]
        public string Country { get; set; }

        public string City { get; set; }

        public List<string> Sources { get; set; }

        public List<string> Tlds { get; set; }

        public int? LengthMax { get; set; }

        public int? LengthMin { get; set; }

        public int? Limit { get; set; }

        public int? WaitMs { get; set; }
    }
}
