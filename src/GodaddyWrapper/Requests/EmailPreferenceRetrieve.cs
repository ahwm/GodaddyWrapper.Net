using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class EmailPreferenceRetrieve
    {
        public bool? backupCreated { get; set; }
        public bool? serverCreated { get; set; }
        public bool? snapshotCreated { get; set; }
        public bool? addressChanged { get; set; }
        public bool? serverStopped { get; set; }
        public bool? snapshotDestroyed { get; set; }
        public bool? serverStarted { get; set; }
        public bool? enabled { get; set; }
        public bool? serverDestroyed { get; set; }
    }
}
