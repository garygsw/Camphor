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
    public partial class AddProgramPage : Form {
        public bool isConfirm { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }

        public AddProgramPage(DateTime date) {
            InitializeComponent();
            isConfirm = false;
            dateBox.Value = date;
            startTimeComboBox.SelectedIndex = 0;
            endTimeComboBox.SelectedIndex = 0;
        }


        private void button1_Click(object sender, EventArgs e) {
            if (this.nameTextBox.Text == "" || this.descriptionTextBox.Text == "") {
                MessageBox.Show("Fields must not be kept empty", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (startTimeComboBox.SelectedIndex >=  endTimeComboBox.SelectedIndex) {
                MessageBox.Show("The start time cannot be equal or later than the end time.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            name = nameTextBox.Text;
            description = descriptionTextBox.Text;
            startTime = dateBox.Value.AddHours(startTimeComboBox.SelectedIndex);
            endTime = dateBox.Value.AddHours(endTimeComboBox.SelectedIndex);
            isConfirm = true;

            this.Hide();
        }

        private void backButton_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
