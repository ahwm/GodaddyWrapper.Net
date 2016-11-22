using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class DomainAvailable
    {
        //[RegularExpression(@"^[^.]{1,63}.[^.]{2,}$")]
        [Required]
        public string domain { get; set; }
        public string checkType { get; set; }
        public bool forTransfer { get; set; }
    }
}
