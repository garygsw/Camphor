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
    public partial class SeeEventDetailsPage : Form {

        public bool isJoin = false;
        public int role = 0;

        public SeeEventDetailsPage(string eventName, string eventStartDate, string eventEndDate, string description) {
            InitializeComponent();
            this.nameBox.Text = eventName;
            this.startDateBox.Text = eventStartDate;
            this.endDateBox.Text = eventEndDate;
            this.descriptionBox.Text = description;
            comboBox1.SelectedIndex = 0;
        }

        public SeeEventDetailsPage(string eventName, string eventStartDate, string eventEndDate, string description, bool edit) {
            // overloaded constructor for viewing already joined events
            InitializeComponent();
            this.nameBox.Text = eventName;
            this.startDateBox.Text = eventStartDate;
            this.endDateBox.Text = eventEndDate;
            this.descriptionBox.Text = description;
            comboBox1.Visible = false;
            joinEventButton.Visible = false;
            label5.Visible = false;
        }

        private void joinEventButton_Click(object sender, EventArgs e) {
            if (comboBox1.SelectedIndex == 0) role = 3;
            if (comboBox1.SelectedIndex == 1) role = 2;
            if (comboBox1.SelectedIndex == 2) role = 1;
            isJoin = true;           
            this.Hide();
        }

        private void closeButton_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
