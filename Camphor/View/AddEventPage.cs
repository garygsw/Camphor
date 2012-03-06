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
    public partial class AddEventPage : Form {
        public bool isConfirm { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public decimal campFee { get; set; }

        public AddEventPage() {
            InitializeComponent();
            isConfirm = false;
        }

        public AddEventPage (string name, string description, DateTime startDate, DateTime endDate, decimal campFee) {
            InitializeComponent();
            nameBox.Text = name;
            descriptionBox.Text = description;
            startDatePicker.Value = startDate;
            endDatePicker.Value = endDate;
            campFeeBox.Value = campFee;
            this.Text = "Edit Event";
            isConfirm = false;
        }

        private void confirmButton_Click(object sender, EventArgs e) {
            if (this.nameBox.Text == "" || this.descriptionBox.Text == "") {
                MessageBox.Show("Fields must not be kept empty", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            } 
            if (DateTime.Compare(this.startDatePicker.Value.Date, this.endDatePicker.Value.Date) > 0) {
                MessageBox.Show("The start date cannot be later than the end date.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            } 

            name = nameBox.Text;
            description = descriptionBox.Text;
            startDate = startDatePicker.Value;
            endDate = endDatePicker.Value;
            campFee = campFeeBox.Value;
            
            isConfirm = true;
            this.Hide();
        }

        private void backButton_Click(object sender, EventArgs e) {

            this.Close();
        }
    }
}
