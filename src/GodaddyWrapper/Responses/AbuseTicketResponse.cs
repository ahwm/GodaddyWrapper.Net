using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class AbuseTicketResponse
    {
        public string TicketId { get; set; }
        public string Reporter { get; set; }
        public string DomainIp { get; set; }
        public string Closed { get; set; }
        public string Type { get; set; }
        public string Target { get; set; }
        public string Source { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ClosedAt { get; set; }
    }
}
