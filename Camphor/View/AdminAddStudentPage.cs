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
    public partial class AdminAddStudentPage : Form {
        public bool checkSaved { get; set; }
        public Gender gender { get; set; }
        public string matric { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string school { get; set; }

        public AdminAddStudentPage () {
            // FUNCTION: intialise for adding student
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            InitializeComponent();
            checkSaved = false;
        }

        public AdminAddStudentPage (string name, Gender gender, string matric, string password, string school) {
            // FUNCTION: intialise for edditing student
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 

            InitializeComponent();
            this.matricTextbox.Enabled = false;
            this.matric = matric;
            this.gender = gender;
            this.name = name;
            this.password = password;
            this.school = school;
            this.nameTextbox.Text = name;
            this.matricTextbox.Text = matric;
            this.passwordTextbox.Text = password;
            this.schoolCombobox.Text = school;
            this.genderComboBox.Text = gender.ToString();
            checkSaved = false;
            this.Text = "Edit Student Particulars";
        }

        private void saveButton_Click (object sender, EventArgs e) {
            // FUNCTION: return save
            // PRE-CONDITIONS: all fields must not be empty
            // POST-CONDITIONS: 
            checkSaved = true;
            if (this.nameTextbox.Text == "" || matricTextbox.Text == "" || genderComboBox.Text == "" || passwordTextbox.Text == "" || schoolCombobox.Text == "") {
                MessageBox.Show("Fields must not be kept empty", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } else {
                name = nameTextbox.Text;
                matric = matricTextbox.Text;
                password = passwordTextbox.Text;
                school = schoolCombobox.Text;
                gender = (Gender) Enum.Parse(typeof(Gender), genderComboBox.Text);
                this.Hide();
            }
        }

        private void backButton_Click (object sender, EventArgs e) {
            // FUNCTION: cancel the change
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            checkSaved = false;
            this.Hide();
        }





    }
}
