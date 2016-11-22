using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CloudSSHKeyCreate
    {
        public string key { get; set; }
        public int name { get; set; }
    }
}
