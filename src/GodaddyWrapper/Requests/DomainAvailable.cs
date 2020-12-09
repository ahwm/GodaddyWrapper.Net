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
        public string Domain { get; set; }
        public string CheckType { get; set; }
        public bool ForTransfer { get; set; }
    }
}
