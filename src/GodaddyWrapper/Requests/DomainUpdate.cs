using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class DomainUpdate
    {
        public bool locked { get; set; }
        public List<object> nameServers { get; set; }
        public bool renewAuto { get; set; }
        public string subaccountId { get; set; }
    }
}
