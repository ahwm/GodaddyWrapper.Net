using System;

namespace GodaddyWrapper.Responses
{
    public class MaintenanceResponse
    {
        public string MaintenanceId { get; set; }
        public string Environment { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? StartsAt { get; set; }
        public DateTime? EndsAt { get; set; }
    }
}
