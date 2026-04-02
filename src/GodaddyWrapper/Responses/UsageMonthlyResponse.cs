using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    public class UsageMonthlyResponse
    {
        public string Yyyymm { get; set; }
        public int Total { get; set; }
        public int? Quota { get; set; }
        public List<UsageMonthlyDetailResponse> Details { get; set; }
    }

    public class UsageMonthlyDetailResponse
    {
        public string Path { get; set; }
        public int Total { get; set; }
    }
}
