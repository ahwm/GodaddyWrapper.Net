using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class EmailPreferenceRetrieve
    {
        public bool? BackupCreated { get; set; }
        public bool? ServerCreated { get; set; }
        public bool? SnapshotCreated { get; set; }
        public bool? AddressChanged { get; set; }
        public bool? ServerStopped { get; set; }
        public bool? SnapshotDestroyed { get; set; }
        public bool? ServerStarted { get; set; }
        public bool? Enabled { get; set; }
        public bool? ServerDestroyed { get; set; }
    }
}
