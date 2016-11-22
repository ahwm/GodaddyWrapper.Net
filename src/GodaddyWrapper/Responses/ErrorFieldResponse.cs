using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class ErrorFieldResponse
    {
        public string Path { get; set; }
        public string PathRelated { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
