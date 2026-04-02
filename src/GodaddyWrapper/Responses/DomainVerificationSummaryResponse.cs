using System;

namespace GodaddyWrapper.Responses
{
    public class DomainVerificationSummaryResponse
    {
        public string Domain { get; set; }
        public int? DomainEntityId { get; set; }
        public string DceToken { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
