using System;

namespace GodaddyWrapper.Responses
{
    public class DomainNotificationResponse
    {
        public string NotificationId { get; set; }
        public string Type { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
