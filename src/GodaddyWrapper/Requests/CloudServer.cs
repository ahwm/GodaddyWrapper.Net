using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CloudServer
    {
        public string privateIp { get; set; }
        public string imageId { get; set; }
        public bool backupsEnabled { get; set; }
        public string description { get; set; }
        public string specId { get; set; }
        public string publicIp { get; set; }
        public string dataCenterId { get; set; }
        public string modifiedAt { get; set; }
        public string status { get; set; }
        public string backupScheduleId { get; set; }
        public string createdAt { get; set; }
        public string zoneId { get; set; }
        public string hostname { get; set; }
        public string username { get; set; }
        public string sshKeyId { get; set; }
        public string taskState { get; set; }
        public string serverId { get; set; }
    }
}
