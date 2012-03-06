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
    public partial class AddTaskPage : Form {
        public bool isConfirm { get; set; }
        public string name { get; set; }
        public string matric { get; set; }
        public string inChargeName { get; set; }
        public DateTime deadline { get; set; }
        public string description { get; set; }
        Server server;
        int eventId;

        public AddTaskPage(Server server, int eventId) {
            InitializeComponent();
            isConfirm = false;
            this.server = server;
            this.eventId = eventId;
        }

        public AddTaskPage (string name, string matric, string inChargeName, DateTime deadline, string description, Server server, int eventId) {
            InitializeComponent();
            isConfirm = false;
            this.matric = matric;
            this.inChargeName = inChargeName;
            this.server = server;
            this.eventId = eventId;
            nameTextBox.Text = name;
            descriptionTextBox.Text = description;
            inChargeTextBox.Text = inChargeName;
            deadlineBox.Value = deadline;
            this.Text = "Edit Task";
        }

        private void button1_Click(object sender, EventArgs e) {
            if (this.nameTextBox.Text == "" || inChargeTextBox.Text == "" || descriptionTextBox.Text == "") {
                MessageBox.Show("Fields must not be empty", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            isConfirm = true;
            name = nameTextBox.Text;
            description = descriptionTextBox.Text;
            deadline = deadlineBox.Value;

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            AddStudentPage addstudent = new AddStudentPage(server, eventId, false);
            addstudent.ShowDialog();
            if (addstudent.isConfirm) {
                inChargeTextBox.Text = addstudent.name;
                inChargeName = addstudent.name;
                matric = addstudent.matric;

            }
        }

        private void backButton_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
