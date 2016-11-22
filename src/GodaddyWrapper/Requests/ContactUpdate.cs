using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class ContactUpdate
    {
        [MinLength(1)]
        [MaxLength(30)]
        [Required]
        public string nameFirst { get; set; }
        public string nameMiddle { get; set; }
        [MinLength(0)]
        [MaxLength(30)]
        [Required]
        public string nameLast { get; set; }
        [MinLength(0)]
        [MaxLength(100)]
        public string organization { get; set; }
        public string jobTitle { get; set; }
        [MinLength(1)]
        [MaxLength(80)]
        [EmailAddress]
        [Required]
        public string email { get; set; }
        [MinLength(1)]
        [MaxLength(17)]
        [Required]
        public string phone { get; set; }
        [MinLength(0)]
        [MaxLength(17)]
        [Required]
        public string fax { get; set; }
        public Address addressMailing { get; set; }
    }
}
