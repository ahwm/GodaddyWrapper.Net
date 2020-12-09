using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CloudSSHKeyRetrieve
    {
        public string Name { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
    }
}
