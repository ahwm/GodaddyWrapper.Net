using System;
using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    public class AgentStatusResponse
    {
        public string Status { get; set; }
        public string Phase { get; set; }
        public List<string> CompletedSteps { get; set; }
        public List<string> PendingSteps { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }
}
