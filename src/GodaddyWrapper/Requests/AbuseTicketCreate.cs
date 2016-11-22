using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class AbuseTicketCreate
    {
        public string type { get; set; }
        public string source { get; set; }
        public string target { get; set; }
        public string proxy { get; set; }
        public string intentional { get; set; }
        public string info { get; set; }
        public string infoUrl { get; set; }
    }
}
