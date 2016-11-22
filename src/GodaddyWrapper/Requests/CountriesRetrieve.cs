using GodaddyWrapper.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CountriesRetrieve
    {
        [Required]
        public int MarketId { get; set; }
        public int RegionTypeId { get; set; }
        public string RegionName { get; set; }
        public string Sort { get; set; }
        public string Order { get; set; }
    }
}
