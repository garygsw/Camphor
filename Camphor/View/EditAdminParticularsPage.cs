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
    public partial class EditAdminParticularsPage : Form {
        public EditAdminParticularsPage () {
            InitializeComponent();
            checkSave = false;
        }

        public bool checkSave { get; set; }
        public string password { get; set; }

        private void saveButton_Click (object sender, EventArgs e) {
            // FUNCTION: Save and close this dialog box
            // PRE-CONDITIONS: At least password inside
            // POST-CONDITIONS: 
            if (passwordTextbox.Text == "") {
                MessageBox.Show("Password cannot be empty", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } else {
                checkSave = true;
                password = passwordTextbox.Text;
                this.Hide();
            }
        }

        private void cancelButton_Click (object sender, EventArgs e) {
            this.Close();
        }

    }
}
