using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CloudSpecsRetrieve
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string Limit { get; set; }
        public string Offset { get; set; }
    }
}
