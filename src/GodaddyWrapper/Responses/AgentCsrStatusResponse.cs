using System;

namespace GodaddyWrapper.Responses
{
    public class AgentCsrStatusResponse
    {
        public string CsrId { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime SubmittedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string FailureReason { get; set; }
    }
}
