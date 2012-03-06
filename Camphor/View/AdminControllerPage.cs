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
    public partial class AdminPage : Form {

        Server server;
        AdminManager adminManager;
        private int sortColumn = -1;

        public AdminPage (Server server) {
            InitializeComponent();
            this.server = server;
            adminManager = new AdminManager(server);
            adminManager.GetStudentList(adminListView);
            toolStripStatusLabel1.Text = "Welcome to the Administrator Page.";
        }
        private void adminButtonsDisable () {
            editButton.Enabled = false;
            deleteButton.Enabled = false;
            adminListView.SelectedItems.Clear();
        }
        
        private void addButton_Click (object sender, EventArgs e) {
            // FUNCTION: Add studet
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            AdminAddStudentPage adminAddStudentPage;
            adminButtonsDisable();
            while (true) {
                try {
                    adminAddStudentPage = new AdminAddStudentPage();
                    adminAddStudentPage.ShowDialog();
                    if (!adminAddStudentPage.checkSaved) return;
                    adminManager.AddStudentParticulars(adminAddStudentPage.matric, adminAddStudentPage.gender, 
                        adminAddStudentPage.name, adminAddStudentPage.password, adminAddStudentPage.school);
                    ListViewItem lvi = new ListViewItem(new[] { adminAddStudentPage.name, adminAddStudentPage.gender.ToString(), adminAddStudentPage.matric, adminAddStudentPage.password, adminAddStudentPage.school });
                    adminListView.Items.Add(lvi);
                    toolStripStatusLabel1.Text = "Student <" + adminAddStudentPage.name + "> has been added to the list.";
                    return;
                } catch (ArgumentException) {
                    MessageBox.Show("Students Exists!", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            
        }

        private void editButton_Click (object sender, EventArgs e) {
            // FUNCTION: Edit an student in the list
            // PRE-CONDITIONS: Only one student from the list is selected.
            // POST-CONDITIONS: The item is selected with the new details.
            
            ListViewItem lvi = adminListView.SelectedItems[0];
            AdminAddStudentPage adminEditStudentPage = new AdminAddStudentPage(lvi.SubItems[0].Text, 
                (Gender) Enum.Parse(typeof(Gender), lvi.SubItems[1].Text), lvi.SubItems[2].Text, lvi.SubItems[3].Text, lvi.SubItems[4].Text);
            adminEditStudentPage.ShowDialog();
            adminButtonsDisable();
            if (!adminEditStudentPage.checkSaved) return;
            adminManager.ChangeStudentParticulars(adminEditStudentPage.matric, adminEditStudentPage.name, 
                adminEditStudentPage.password, adminEditStudentPage.school, adminEditStudentPage.gender);
            lvi.SubItems[0].Text = adminEditStudentPage.name;
            lvi.SubItems[1].Text = adminEditStudentPage.gender.ToString();
            lvi.SubItems[3].Text = adminEditStudentPage.password;
            lvi.SubItems[4].Text = adminEditStudentPage.school;
            toolStripStatusLabel1.Text = "Particulars of <" + adminEditStudentPage.name + "> have been editted.";
            
           
        }

        private void deleteButton_Click (object sender, EventArgs e) {
            // FUNCTION: Delete items from the list.
            // PRE-CONDITIONS: At least one item from the list is selected.
            // POST-CONDITIONS: The item is removed from the list.
            
            bool isDeleted = false;

            if (adminListView.SelectedItems.Count >= 1) {
                isDeleted = true;
            }

            foreach (ListViewItem item in adminListView.SelectedItems) {
                adminManager.DeleteStudentParticulars(item.SubItems[1].Text);
                item.Remove();
            }

            if (isDeleted) {
                toolStripStatusLabel1.Text = "Selected student(s) has been deleted.";
            }
            adminButtonsDisable();

        }

        private void logoutButton_Click (object sender, EventArgs e) {
            this.Close();
        }

        private void changeButton_Click (object sender, EventArgs e) {
            // FUNCTION: Change the password of the admin
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            adminButtonsDisable();
            EditAdminParticularsPage editAdminParticularsPage = new EditAdminParticularsPage();
            editAdminParticularsPage.ShowDialog();
            if (!editAdminParticularsPage.checkSave) return;
            else {
                adminManager.SetAdminPassword(editAdminParticularsPage.password);
            }
            toolStripStatusLabel1.Text = "Administrator account password has been changed.";
            
        }

        private void adminListView_ColumnClick (object sender, System.Windows.Forms.ColumnClickEventArgs e) {
            // FUNCTION: Sort the ListView box
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != sortColumn) {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default.
                adminListView.Sorting = SortOrder.Ascending;
            } else {
                // Determine what the last sort order was and change it.
                if (adminListView.Sorting == SortOrder.Ascending)
                    adminListView.Sorting = SortOrder.Descending;
                else
                    adminListView.Sorting = SortOrder.Ascending;
            }

            this.adminListView.ListViewItemSorter = new ListViewItemComparerByString(e.Column, adminListView.Sorting);
            // Call the sort method to manually sort.
            adminListView.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
            
        }

        private void adminListView_SelectedIndexChanged(object sender, EventArgs e) {
            if (adminListView.SelectedItems.Count > 1 || adminListView.SelectedItems.Count == 0) {
                editButton.Enabled = false;
            } else {
                editButton.Enabled = true;
            }
            
            if (adminListView.SelectedItems.Count == 0) {
                deleteButton.Enabled = false;
            } else {
                deleteButton.Enabled = true;
            }
        }

       

    }
}
