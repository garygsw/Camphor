using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Camphor.Model {
    [Serializable]
    public class Task {
        public string name { get; set; }
        public string inCharge { get; set; }
        public string description { get; set; }
        public DateTime deadline { get; set; }
        public int taskId { get; set; }
        public int programId { get; set; }
        public bool complete { get; set; }

    }

}
 