using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class DomainUpdate
    {
        public bool Locked { get; set; }
        public List<object> NameServers { get; set; }
        public bool RenewAuto { get; set; }
        public string SubaccountId { get; set; }
    }
}
