using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class AbuseTicketCreate
    {
        public string Type { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public string Proxy { get; set; }
        public string Intentional { get; set; }
        public string Info { get; set; }
        public string InfoUrl { get; set; }
    }
}
