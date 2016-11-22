using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class JsonDataTypeResponse
    {
        public string Type { get; set; }
        [JsonProperty("$ref")]
        public string RefVal { get; set; }
        public string Format { get; set; }
        public string Pattern { get; set; }
    }
}
