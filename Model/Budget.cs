using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Camphor.Model {
    [Serializable]
    public class Budget {

        // FUNCTION: Get/Set methods for all variables

        public string description { get; set; }
        public decimal amount { get; set; }
        public int budgetId { get; set; }
                       
    }

}
 