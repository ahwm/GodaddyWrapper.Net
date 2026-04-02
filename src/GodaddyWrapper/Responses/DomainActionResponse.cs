using System;

namespace GodaddyWrapper.Responses
{
    public class DomainActionResponse
    {
        public string Type { get; set; }
        public string Origination { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
        public string RequestId { get; set; }
    }
}
