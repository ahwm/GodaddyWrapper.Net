using GodaddyWrapper.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CloudServerCreate
    {
        public bool? BackupsEnabled { get; set; }
        public string SshKeyId { get; set; }
        public List<string> Volumes { get; set; }
        public string DataCenterId { get; set; }
        public List<string> Addresses { get; set; }
        [Required]
        public string Spec { get; set; }
        public string Description { get; set; }
        public string ZoneId { get; set; }
        public string Password { get; set; }
        [RegularExpression("^[a-zA-Z0-9]([-\\.]{0,1}[a-zA-Z0-9]+)*$")]
        [Required]
        public string Hostname { get; set; }
        public string BootScript { get; set; }
        [RegularExpression("^[a-z_][a-z0-9_]{,31}$")]
        [MinLength(1)]
        [MaxLength(32)]
        [Required]
        public string Username { get; set; }
        public string Discount { get; set; }
        [Required]
        public string Image { get; set; }
    }
}
