using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class Contact
    {
        [MinLength(1)]
        [MaxLength(30)]
        [Required]
        public string NameFirst { get; set; }
        public string NameMiddle { get; set; }
        [MinLength(1)]
        [MaxLength(30)]
        [Required]
        public string NameLast { get; set; }
        [MinLength(0)]
        [MaxLength(100)]
        public string Organization { get; set; }
        public string JobTitle { get; set; }
        [MinLength(1)]
        [MaxLength(80)]
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [MinLength(1)]
        [MaxLength(17)]
        [Required]
        public string Phone { get; set; }
        [MinLength(0)]
        [MaxLength(17)]
        [Required]
        public string Fax { get; set; }
        public Address AddressMailing { get; set; }
    }
}
