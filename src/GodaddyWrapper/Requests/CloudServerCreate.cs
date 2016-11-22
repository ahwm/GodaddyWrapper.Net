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
        public bool? backupsEnabled { get; set; }
        public string sshKeyId { get; set; }
        public List<string> volumes { get; set; }
        public string dataCenterId { get; set; }
        public List<string> addresses { get; set; }
        [Required]
        public string spec { get; set; }
        public string description { get; set; }
        public string zoneId { get; set; }
        public string password { get; set; }
        [RegularExpression("^[a-zA-Z0-9]([-\\.]{0,1}[a-zA-Z0-9]+)*$")]
        [Required]
        public string hostname { get; set; }
        public string bootScript { get; set; }
        [RegularExpression("^[a-z_][a-z0-9_]{,31}$")]
        [MinLength(1)]
        [MaxLength(32)]
        [Required]
        public string username { get; set; }
        public string discount { get; set; }
        [Required]
        public string image { get; set; }
    }
}
