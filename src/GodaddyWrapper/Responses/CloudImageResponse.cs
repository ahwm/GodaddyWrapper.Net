using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class CloudImageResponse
    {
        public string ImageId { get; set; }
        public string Name { get; set; }
        public string DataCenterId { get; set; }
        public string ModifiedAt { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string SourceImageId { get; set; }
        public string CreatedAt { get; set; }
        public string SourceServerId { get; set; }
        public string Version { get; set; }
        public string RootImageId { get; set; }
        public string SizeMb { get; set; }


    }
}
