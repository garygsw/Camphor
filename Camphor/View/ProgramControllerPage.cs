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
    public partial class ProgramControllerPage : Form {
        public ProgramControllerPage() {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) {
            AddEventPage addevent = new AddEventPage();
            addevent.Show();
        }

        private void button6_Click(object sender, EventArgs e) {
            //AddTaskPage addtask = new AddTaskPage();
            // addtask.Show();
        }

        private void button1_Click(object sender, EventArgs e) {
            AddLogisticsItemPage additem = new AddLogisticsItemPage();
            additem.Show();
        }

        private void button5_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
