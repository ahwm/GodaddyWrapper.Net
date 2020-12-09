using GodaddyWrapper.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CloudServerRetrieve
    {
        public string Status { get; set; }
        public bool BackupsEnabled { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
    }
}
