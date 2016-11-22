using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class CloudSpecResponse
    {
        public string Status { get; set; }
        public string Name { get; set; }
        public long DiskGb { get; set; }
        public string CreatedAt { get; set; }
        public string ModifiedAt { get; set; }
        public string SpecId { get; set; }
        public long RamMb { get; set; }
        public long CpuCores { get; set; }
    }
}
