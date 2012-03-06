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
    public partial class EditManpowerPage : Form {
        Server server;
        string matric;
        int eventID;
        EventManpowerManager eventManpowerManager;
        int organiserListViewSortColumn = -1;
        int facilitatorListViewSortColumn = -1;
        int participantListViewSortColumn = -1;

        public EditManpowerPage(Server server, int eventID, string matric) {
            InitializeComponent();
            eventManpowerManager = new EventManpowerManager(server);
            this.server = server;
            this.matric = matric;
            this.eventID = eventID;
            eventManpowerManager.GetOrganiserList(organiserListView, eventID);
            eventManpowerManager.GetFacilitatorList(facilitatorListView, eventID);
            eventManpowerManager.GetParticipantList(participantListView, eventID);
        }

        private void closeButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void addStudentButton_Click(object sender, EventArgs e) {
            ListView currentListView = organiserListView;
            int role = 1;
            if (tabControl.SelectedIndex == 1) {
                currentListView = facilitatorListView;
                role = 2;
            } else if (tabControl.SelectedIndex == 2) {
                currentListView = participantListView;
                role = 3;
            }
            
            AddStudentPage addstudent = new AddStudentPage(server, eventID, true);
            addstudent.ShowDialog();
            if (addstudent.isConfirm) {
                string matric = addstudent.matric;
                string name = addstudent.name;
                bool alreadyExists = false;
                string alreadyExistsAs = "";

                // check if name already exists in the events 

                //check organiser list
                foreach (ListViewItem student in organiserListView.Items) {
                    if (student.SubItems[1].Text == matric) {
                        alreadyExists = true;
                        alreadyExistsAs = "Organiser";
                    }
                }

                //check facilitator list
                foreach (ListViewItem student in facilitatorListView.Items) {
                    if (student.SubItems[1].Text == matric) {
                        alreadyExists = true;
                        alreadyExistsAs = "Facilitator";
                    }
                }

                //check participants list
                foreach (ListViewItem student in participantListView.Items) {
                    if (student.SubItems[1].Text == matric) {
                        alreadyExists = true;
                        alreadyExistsAs = "Participant";
                    }
                }

                if (alreadyExists) {
                     MessageBox.Show("Student already exists in the event as <" + alreadyExistsAs + ">", 
                            "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                eventManpowerManager.StudentJoinEvent(matric, eventID, role);
                ListViewItem newStudent = new ListViewItem(new[] { name, matric, "No" });
                currentListView.Items.Add(newStudent);

                string roleInWords = "";
                if (role == 1) roleInWords = "Organiser";
                else if (role == 2) roleInWords = "Facilitator";
                else roleInWords = "Participant";
                toolStripStatusLabel1.Text = "Student <" + name + "> has been added to the " + roleInWords + "'s list.";
            }
            addstudent.Close();
        }

        private void deleteStudentButton_Click(object sender, EventArgs e) {
            
            ListView currentListView = organiserListView;
            int role = 1;

            if (tabControl.SelectedIndex == 1) {
                currentListView = facilitatorListView;
                role = 2;
            } else if (tabControl.SelectedIndex == 2) {
                currentListView = participantListView;
                role = 3;
            }

            // check if the organiser got select his own self or not.
            if (role == 1) {
                foreach (ListViewItem student in currentListView.SelectedItems) {
                    string studentMatric = student.SubItems[1].Text;
                    if (studentMatric == matric) {
                        MessageBox.Show("You cannot delete your own self.", 
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }

            foreach (ListViewItem student in currentListView.SelectedItems) {
                string studentMatric = student.SubItems[1].Text;
                eventManpowerManager.RemoveStudent(studentMatric, eventID, role);
                student.Remove();
            }
            string roleInWords = "";
            if (role == 1) roleInWords = "Organiser";
            else if (role == 2) roleInWords = "Facilitator";
            else roleInWords = "Participant";
            toolStripStatusLabel1.Text = "Selected student(s) have been deleted from the " + roleInWords + "'s list.";
        }

        private void organiserListView_SelectedIndexChanged(object sender, EventArgs e) {
            if (organiserListView.SelectedItems.Count > 0) {
                deleteStudentButton.Enabled = true;
                markAsPaidButton.Enabled = true;
                markAsUnpaidButton.Enabled = true;
            } else {
                deleteStudentButton.Enabled = false;
                markAsPaidButton.Enabled = false;
                markAsUnpaidButton.Enabled = false;
            }
        }

        private void facilitatorListView_SelectedIndexChanged(object sender, EventArgs e) {
            if (facilitatorListView.SelectedItems.Count > 0) {
                deleteStudentButton.Enabled = true;
                markAsPaidButton.Enabled = true;
                markAsUnpaidButton.Enabled = true;
            } else {
                deleteStudentButton.Enabled = false;
                markAsPaidButton.Enabled = false;
                markAsUnpaidButton.Enabled = false;
            }
        }

        private void participantListView_SelectedIndexChanged(object sender, EventArgs e) {
            if (participantListView.SelectedItems.Count > 0) {
                deleteStudentButton.Enabled = true;
                markAsPaidButton.Enabled = true;
                markAsUnpaidButton.Enabled = true;
            } else {
                deleteStudentButton.Enabled = false;
                markAsPaidButton.Enabled = false;
                markAsUnpaidButton.Enabled = false;
            }
        }

        private void markAsPaidButton_Click(object sender, EventArgs e) {
            ListView currentListView = organiserListView;
            int role = 1;
            if (tabControl.SelectedIndex == 1) {
                currentListView = facilitatorListView;
                role = 2;
            } else if (tabControl.SelectedIndex == 2) {
                currentListView = participantListView;
                role = 3;
            }
            foreach (ListViewItem student in currentListView.SelectedItems) {
                string matric = student.SubItems[1].Text;
                student.SubItems[2].Text = "Yes";

                eventManpowerManager.EditStudentPaidStatus(matric, eventID, role, true);
            }
            toolStripStatusLabel1.Text = "Selected student(s) have been marked as paid for the camp.";
        }

        private void markAsUnpaidButton_Click(object sender, EventArgs e) {
            ListView currentListView = organiserListView;
            int role = 1;
            if (tabControl.SelectedIndex == 1) {
                currentListView = facilitatorListView;
                role = 2;
            } else if (tabControl.SelectedIndex == 2) {
                currentListView = participantListView;
                role = 3;
            }

            foreach (ListViewItem student in currentListView.SelectedItems) {
                string matric = student.SubItems[1].Text;
                student.SubItems[2].Text = "No";

                eventManpowerManager.EditStudentPaidStatus(matric, eventID, role, false);
            }
            toolStripStatusLabel1.Text = "Selected student(s) have been marked as unpaid for the camp.";
        }

        private void organiserListView_ColumnClick(object sender, ColumnClickEventArgs e) {
            // FUNCTION: Sort the ListView box
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != organiserListViewSortColumn) {
                // Set the sort column to the new column.
                organiserListViewSortColumn = e.Column;
                // Set the sort order to ascending by default.
                organiserListView.Sorting = SortOrder.Ascending;
            } else {
                // Determine what the last sort order was and change it.
                if (organiserListView.Sorting == SortOrder.Ascending)
                    organiserListView.Sorting = SortOrder.Descending;
                else
                    organiserListView.Sorting = SortOrder.Ascending;
            }

            this.organiserListView.ListViewItemSorter = new ListViewItemComparerByString(e.Column, organiserListView.Sorting);
            // Call the sort method to manually sort.
            organiserListView.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
        }

        private void facilitatorListView_ColumnClick(object sender, ColumnClickEventArgs e) {
            // FUNCTION: Sort the ListView box
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != facilitatorListViewSortColumn) {
                // Set the sort column to the new column.
                facilitatorListViewSortColumn = e.Column;
                // Set the sort order to ascending by default.
                facilitatorListView.Sorting = SortOrder.Ascending;
            } else {
                // Determine what the last sort order was and change it.
                if (facilitatorListView.Sorting == SortOrder.Ascending)
                    facilitatorListView.Sorting = SortOrder.Descending;
                else
                    facilitatorListView.Sorting = SortOrder.Ascending;
            }

            this.facilitatorListView.ListViewItemSorter = new ListViewItemComparerByString(e.Column, facilitatorListView.Sorting);
            // Call the sort method to manually sort.
            facilitatorListView.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
        }

        private void participantListView_ColumnClick(object sender, ColumnClickEventArgs e) {
            // FUNCTION: Sort the ListView box
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != participantListViewSortColumn) {
                // Set the sort column to the new column.
                participantListViewSortColumn = e.Column;
                // Set the sort order to ascending by default.
                participantListView.Sorting = SortOrder.Ascending;
            } else {
                // Determine what the last sort order was and change it.
                if (participantListView.Sorting == SortOrder.Ascending)
                    participantListView.Sorting = SortOrder.Descending;
                else
                    participantListView.Sorting = SortOrder.Ascending;
            }

            this.participantListView.ListViewItemSorter = new ListViewItemComparerByString(e.Column, participantListView.Sorting);
            // Call the sort method to manually sort.
            participantListView.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
        }
    }
}
