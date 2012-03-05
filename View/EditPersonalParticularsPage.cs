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
    public partial class EditPersonalParticularsPage : Form {
        public string password { get; set; }
        public string name { get; set; }
        public bool checkSave { get; set; }

        public EditPersonalParticularsPage(string matric, string name, string school, string password) {
            InitializeComponent();
            nameTextbox.Text = name;
            matricTextbox.Text = matric;
            schoolTextbox.Text = school;
            passwordTextBox.Text = password;
            checkSave = false;
        }


        private void saveButton_Click(object sender, EventArgs e) {
            // FUNCTION: save the data
            // PRE-CONDITIONS: the box cannot be empty
            // POST-CONDITIONS: 
            if (passwordTextBox.Text == "" || nameTextbox.Text == "") {
                MessageBox.Show("Password or Name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            password = passwordTextBox.Text;
            name = nameTextbox.Text;
            checkSave = true;
            this.Hide();
        }

        private void cancelButton_Click (object sender, EventArgs e) {
            // FUNCTION: close the form
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            this.Hide();
        }

    }
}
