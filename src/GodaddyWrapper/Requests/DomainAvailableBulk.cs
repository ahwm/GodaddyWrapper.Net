using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class DomainAvailableBulk
    {
        public List<string> Domains { get; set; }
        public string CheckType { get; set; }
    }
}
