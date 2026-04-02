using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GodaddyWrapper.Responses
{
    public class UsageMonthlyResponse
    {
        [JsonPropertyName("yyyymm")]
        public string YearMonth { get; set; }
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
