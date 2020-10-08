using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class AbuseTicketRetrieve
    {
        public string Type { get; set; }
        public bool Closed { get; set; }
        public string SourceDomainOrIp { get; set; }
        public string Target { get; set; }
        public DateTime CreatedStart { get; set; }
        public DateTime CreatedEnd { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
    }
}
