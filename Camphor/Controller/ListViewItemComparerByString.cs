﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Camphor.Model;
using Camphor.View;

namespace Camphor.Controller {
    class ListViewItemComparerByString : IComparer {
        private int col;
        private SortOrder order;
        public ListViewItemComparerByString () {
            col = 0;
            order = SortOrder.Ascending;
        }
        public ListViewItemComparerByString (int column, SortOrder order) {
            col = column;
            this.order = order;
        }
        public int Compare (object x, object y) {
            int returnVal = -1;
            returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                    ((ListViewItem)y).SubItems[col].Text);
            // Determine whether the sort order is descending.
            if (order == SortOrder.Descending)
                // Invert the value returned by String.Compare.
                returnVal *= -1;
            return returnVal;
        }
    }
}

