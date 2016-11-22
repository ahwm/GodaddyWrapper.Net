using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CloudSpecsRetrieve
    {
        public string name { get; set; }
        public string status { get; set; }
        public string limit { get; set; }
        public string offset { get; set; }
    }
}
