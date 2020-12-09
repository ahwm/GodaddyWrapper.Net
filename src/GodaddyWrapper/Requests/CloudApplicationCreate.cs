using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CloudApplicationCreate
    {
        public List<string> Ports { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public int MinimumRamMb { get; set; }
        public string ChangelogUrl { get; set; }
        public List<string> Categories { get; set; }
        public List<CloudApplicationInputField> Inputs { get; set; }
        public List<CloudApplicationLink> Links { get; set; }

    }
}
