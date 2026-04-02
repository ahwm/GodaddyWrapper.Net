namespace GodaddyWrapper.Responses
{
    public class AgentDnsRecord
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public string Purpose { get; set; }
        public bool Required { get; set; }
        public int Ttl { get; set; }
        public int? Priority { get; set; }
    }
}
