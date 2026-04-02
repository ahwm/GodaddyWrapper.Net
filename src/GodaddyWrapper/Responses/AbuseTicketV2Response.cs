using System;

namespace GodaddyWrapper.Responses
{
    public class AbuseTicketV2Response
    {
        public string TicketId { get; set; }
        public string Reporter { get; set; }
        public string DomainIp { get; set; }
        public bool Closed { get; set; }
        public string Type { get; set; }
        public string Target { get; set; }
        public string Source { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        public string CloseReason { get; set; }
    }
}
