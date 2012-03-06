using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Camphor.Model {
    [Serializable]
    public class Logistic {

        // FUNCTION: Get/Set methods for all variables

        public string name { get; set; }
        public string description { get; set; }
        public decimal amount { get; set; }
        public int quantity { get; set; } 
        public int logisticId { get; set; }
        public int programId { get; set; }
                       
    }

}
 