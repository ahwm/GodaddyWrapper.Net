using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CloudApplicationInputField
    {
        public string Type { get; set; }
        public string Name { get; set; }
        [JsonProperty("default")]
        public string DefaultVal { get; set; }
        public List<CloudApplicationInputFieldValidator> Validators { get; set; }

    }
}
