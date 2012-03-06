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
    public partial class AddLogisticsItemPage : Form {
        public bool isConfirm { get; set; }
        public string name { get; set; }
        public decimal amount { get; set; }
        public int quantity { get; set; }
        public string description { get; set; }

        public AddLogisticsItemPage() {
            InitializeComponent();
            isConfirm = false;
        }

        public AddLogisticsItemPage (string name, decimal amount, int quantity, string description) {
            InitializeComponent();
            isConfirm = false;
            nameTextBox.Text = name;
            amountBox.Value = amount;
            QuantityBox.Value = quantity;
            descriptionTextBox.Text = description;
            this.Text = "Edit Logistics Item";

        }


        private void button1_Click(object sender, EventArgs e) {
            if (this.nameTextBox.Text == "" || this.descriptionTextBox.Text == "") {
                MessageBox.Show("Fields must not be kept empty", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            name = nameTextBox.Text;
            amount = amountBox.Value;
            quantity = Convert.ToInt32(QuantityBox.Value);
            description = descriptionTextBox.Text;

            isConfirm = true;
            this.Hide();
        }

        private void backButton_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
