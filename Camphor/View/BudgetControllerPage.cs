using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Camphor {
    public partial class BudgetControllerPage : Form {
        public BudgetControllerPage() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e) {
            AddBudgetItemPage addbudget = new AddBudgetItemPage();
            addbudget.Show();
        }
    }
}
