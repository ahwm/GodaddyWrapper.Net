using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class CloudApplicationResponse
    {
        public string Name { get; set; }
        public string CreatedAt { get; set; }
        public int MinimumRamMb { get; set; }
        public List<CloudApplicationLinkResponse> Links { get; set; }
        public string Status { get; set; }
        public List<CloudApplicationInputFieldResponse> Inputs { get; set; }
        public string ApplicationId { get; set; }
        public string Description { get; set; }
        public string ModifiedAt { get; set; }
        public string Version { get; set; }
        public string ChangelogUrl { get; set; }
        public List<string> Categories { get; set; }
        public List<string> Ports { get; set; }
        public List<string> ImageIds { get; set; }

    }
}
