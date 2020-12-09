using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CloudApplicationRetrieve
    {
        public string Category { get; set; }
        public string ImageId { get; set; }
        public string Status { get; set; }
        public string Limit { get; set; }
        public string Offset { get; set; }

    }
}
