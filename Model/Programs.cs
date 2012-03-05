using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Camphor.Model {
    [Serializable]
    public class Programs {

        // FUNCTION: Get/Set methods for all variables
        public int programId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }

    }
}
