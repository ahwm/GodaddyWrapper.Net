using GodaddyWrapper.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class SubscriptionRetrieve
    {
        public List<string> ProductGroupKeys { get; set; }
        public List<string> Includes { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
        public string Sort { get; set; }
    }
}
