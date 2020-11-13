using GodaddyWrapper.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class DomainRetrieve
    {
        public List<string> Statuses { get; set; }
        public List<string> StatusGroups { get; set; }
        public int? Limit { get; set; }
        public string Marker { get; set; }
        public List<string> Includes { get; set; }
        public string ModifiedDate { get; set; }
    }
}
