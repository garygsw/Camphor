using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Camphor {
    public partial class TaskControllerPage : Form {
        public TaskControllerPage() {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e) {
            AddTaskPage addtask = new AddTaskPage();
            addtask.Show();
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
