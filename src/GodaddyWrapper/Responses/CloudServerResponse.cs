using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class CloudServerResponse
    {
        public string PrivateIp { get; set; }
        public string ImageId { get; set; }
        public bool BackupsEnabled { get; set; }
        public string Description { get; set; }
        public string SpecId { get; set; }
        public string PublicIp { get; set; }
        public string DataCenterId { get; set; }
        public string ModifiedAt { get; set; }
        public string Status { get; set; }
        public string BackupScheduleId { get; set; }
        public string CreatedAt { get; set; }
        public string ZoneId { get; set; }
        public string Hostname { get; set; }
        public string Username { get; set; }
        public string SshKeyId { get; set; }
        public string TaskState { get; set; }
        public string ServerId { get; set; }
    }
}
