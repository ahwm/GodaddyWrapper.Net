using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class JsonSchemaResponse
    {
        public string Id { get; set; }
        public JsonPropertyResponse Properties { get; set; }
        public List<string> Required { get; set; }
        public JsonSchemaResponse Models { get; set; }
    }
}
