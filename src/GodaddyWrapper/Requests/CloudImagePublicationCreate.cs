using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CloudImagePublicationCreate
    {
        public List<string> DataCenterIds { get; set; }
        public string ApplicationId { get; set; }
    }
}
