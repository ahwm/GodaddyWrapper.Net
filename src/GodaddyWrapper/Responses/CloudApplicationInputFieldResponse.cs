using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class CloudApplicationInputFieldResponse
    {
        public string Type { get; set; }
        public string Name { get; set; }
        [JsonProperty("default")]
        public string DefaultVal { get; set; }
        public List<CloudApplicationInputFieldValidatorResponse> Validators { get; set; }

    }
}
