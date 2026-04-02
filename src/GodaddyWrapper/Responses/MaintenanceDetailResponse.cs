using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    public class MaintenanceDetailResponse : MaintenanceResponse
    {
        public List<string> Systems { get; set; }
    }
}
