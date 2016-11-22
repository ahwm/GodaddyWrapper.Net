using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class CloudImageActionResponse
    {
        public string ImageId { get; set; }
        public string ImageActionId { get; set; }
        public string CreatedAt { get; set; }
        public string ModifiedAt { get; set; }
        public string Type { get; set; }
        public string CompletedAt { get; set; }

    }
}
