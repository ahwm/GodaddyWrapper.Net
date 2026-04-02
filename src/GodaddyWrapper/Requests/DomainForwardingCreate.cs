using System.ComponentModel.DataAnnotations;

namespace GodaddyWrapper.Requests
{
    public class DomainForwardingCreate
    {
        [Required]
        public string Url { get; set; }
        public string Type { get; set; }
        public DomainForwardingMask Mask { get; set; }
    }

    public class DomainForwardingMask
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
    }
}
