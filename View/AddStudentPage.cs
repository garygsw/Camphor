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
    public partial class AddStudentPage : Form {

        public bool isConfirm { get; set; }
        public string name { get; set; }
        public string matric { get; set; }
        private int eventId;
        public bool isOverall { get; set; }

        EventsOrganizerSearchManager eventsOrganizerSearchManager;

        public AddStudentPage (Server server, int eventId, bool isOverall) {
            InitializeComponent();
            isConfirm = false;
            eventsOrganizerSearchManager = new EventsOrganizerSearchManager(server);
            this.eventId = eventId;
            this.isOverall = isOverall;
            matricTextBox.Focus();
        }

        private void confirmButton_Click (object sender, EventArgs e) {
            if (this.nameTextBox.Text == "") {
                MessageBox.Show("Please Find a Student First", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            isConfirm = true;
            name = nameTextBox.Text;
            matric = matricTextBox.Text;
            this.Hide();
        }

        private void backButton_Click (object sender, EventArgs e) {
            this.Close();
        }

        private void SearchButton_Click (object sender, EventArgs e) {
            if (this.matricTextBox.Text == "") {
                MessageBox.Show("Fields must not be kept empty", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (isOverall) {
                nameTextBox.Text = eventsOrganizerSearchManager.SearchName(matricTextBox.Text);
            } else {
                nameTextBox.Text = eventsOrganizerSearchManager.SearchNameWithinEvent(matricTextBox.Text, eventId);
            }
            if (nameTextBox.Text == "") {
                MessageBox.Show("No Such Student!!", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}

