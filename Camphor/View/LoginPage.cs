using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Camphor.Model;
using Camphor.Controller;

namespace Camphor.View {
    public partial class LoginPage : Form {

        Server server;
        LoginManager loginAdmin;

        public LoginPage () {
            InitializeComponent();
           // server = new Server();
            server = SerLoad();
            loginAdmin = new LoginManager(server);
        }

        private void loginButton_Click (object sender, EventArgs e) {
            // FUNCTION: check for the matric password is correct
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 

            if (passwordTextbox.Text == "" || matricTextbox.Text == "") {
                MessageBox.Show("Please enter your matriculation number and password.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (matricTextbox.Text == "Admin") {
                if (loginAdmin.CheckAdmin(passwordTextbox.Text)) {
                    AdminPage adminPage = new AdminPage(server);
                    this.Hide();
                    adminPage.ShowDialog();
                    SerSave(server);
                    this.passwordTextbox.Clear();
                    this.matricTextbox.Clear();
                    this.Show();
                } else {
                    MessageBox.Show("Pasword in invalid, please try again!", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                matricTextbox.Focus();
                return;
            }

            if (loginAdmin.CheckPassword(matricTextbox.Text, passwordTextbox.Text)) {
                DashBoardPage dashBoardPage = new DashBoardPage(matricTextbox.Text, server);
                this.Hide();
                dashBoardPage.ShowDialog();
                SerSave(server);
                this.passwordTextbox.Clear();
                this.matricTextbox.Clear();
                this.Show();
            } else {
                MessageBox.Show("Invalid matriculation number or password, please try again!", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            matricTextbox.Focus();
            return;
        }

        private void SerSave (Server temp) {
            // FUNCTION: Save the server class
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            using (Stream output = File.Create("Data.dat")) {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(output, temp);
            }
        }

        private Server SerLoad () {
            // FUNCTION: load the server class
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            using (Stream input = File.OpenRead("Data.dat")) {
                BinaryFormatter bf = new BinaryFormatter();
                Server temp = (Server)bf.Deserialize(input);
                return temp;
            }
        }


    }
}
