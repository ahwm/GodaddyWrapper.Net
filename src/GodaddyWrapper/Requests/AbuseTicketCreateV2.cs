using System.ComponentModel.DataAnnotations;

namespace GodaddyWrapper.Requests
{
    public class AbuseTicketCreateV2
    {
        [Required]
        public string Source { get; set; }
        public string Target { get; set; }
        public string Info { get; set; }
        public string InfoUrl { get; set; }
        [Required]
        public string Type { get; set; }
        public string Proxy { get; set; }
        public string Useragent { get; set; }
    }
}
