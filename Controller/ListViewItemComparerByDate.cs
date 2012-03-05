using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using Camphor.Model;
using Camphor.View;

namespace Camphor.Controller {
    class ListViewItemComparerByDate : IComparer {
        private int col;
        private SortOrder order;
        public ListViewItemComparerByDate () {
            col = 0;
            order = SortOrder.Ascending;
        }
        public ListViewItemComparerByDate (int column, SortOrder order) {
            col = column;
            this.order = order;
        }
        public int Compare (object x, object y) {
            int returnVal;
            // Determine whether the type being compared is a date type.
            try {
                // Parse the two objects passed as a parameter as a DateTime.
                DateTime firstDate = DateTime.Parse(((ListViewItem)x).SubItems[col].Text);
                DateTime secondDate = DateTime.Parse(((ListViewItem)y).SubItems[col].Text);
                // Compare the two dates.
                returnVal = DateTime.Compare(firstDate, secondDate);
            }
            // If neither compared object has a valid date format, compare
            // as a string.
            catch {
                // Compare the two items as a string.
                returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                            ((ListViewItem)y).SubItems[col].Text);
            }
            // Determine whether the sort order is descending.
            if (order == SortOrder.Descending)
            // Invert the value returned by String.Compare.
                returnVal *= -1;
            return returnVal;
        }
    }
}
