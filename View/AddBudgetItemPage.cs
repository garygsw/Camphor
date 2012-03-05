using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Camphor.Model;
using Camphor.Controller;

namespace Camphor.View {
    public partial class AddBudgetItemPage : Form {

        public bool isConfirm { get; set; }
        public string name { get; set; }
        public decimal amount { get; set; }


        public AddBudgetItemPage () {
            InitializeComponent();
            isConfirm = false;
        }

        public AddBudgetItemPage (string name, decimal amount) {
            InitializeComponent();
            nameTextBox.Text = name;
            amountTextBox.Value = amount;
            this.Text = "Edit Budget";
            isConfirm = false;
        }

        private void button1_Click (object sender, EventArgs e) {
            if (this.nameTextBox.Text == "") {
                MessageBox.Show("Fields must not be kept empty", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            name = nameTextBox.Text;
            amount = amountTextBox.Value;
            isConfirm = true;
            this.Close();
        }

        private void backButton_Click (object sender, EventArgs e) {
            this.Close();
        }
    }
}
