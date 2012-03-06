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
    public partial class DashBoardPage : Form {
        Server server;
        string matric;
        StudentEventManager studentEventManager;
        DateTimeManager dateManager; 

        int eventListViewSortColumnByName = -1;
        int eventListViewSortColumnByDate = -1;
        int myEventListViewSortColumn = -1;
        int myTaskListViewSortColumn = -1;

        public DashBoardPage (string matric, Server server) {
            InitializeComponent();
            this.server = server;
            this.matric = matric;
            studentEventManager = new StudentEventManager(server);

            this.nameLabel.Text = studentEventManager.GetName(matric);
            this.matricLabel.Text = matric;

            dateManager = new DateTimeManager();
            DateTime today = DateTime.Today;
            this.dateLabel.Text = today.ToString("d") + " |";
            this.weekLabel.Text = dateManager.CurrentAcademicWeek();
            this.academicYearSemLabel.Text = dateManager.CurrentAcademicYear();

            studentEventManager.GetStudentEventsTasks(this.myEventListView, this.myTaskListView, matric);
            studentEventManager.GetEvents(this.eventListView);

        }
        
        private void createEventButton_Click(object sender, EventArgs e) {
            createEvent();
        }

        private void createEvent() {
            dashBoardButtonDisable();
            StudentEventManager studentEventManager = new StudentEventManager(this.server);
            AddEventPage addPage = new AddEventPage();
            addPage.ShowDialog();
            
            if (addPage.isConfirm == true) {
                string campName = addPage.name;
                DateTime startDate = addPage.startDate;
                DateTime endDate = addPage.endDate;
                string description = addPage.description;
                decimal campFee = addPage.campFee;

                int campID = studentEventManager.AddEvents(campName, startDate, endDate, description, campFee);
                
                // add list view
                ListViewItem newEvent = new ListViewItem(new[] { campName, "Organiser", campID.ToString() });
                myEventListView.Items.Add(newEvent);
                
                // use student to add this event
                // set this student as organiser for this event
                Student student = server.GetStudent(this.matric);
                student.AddEvents(this.server, campID, 1);

                addPage.Close();

                EventControllerPage eventControllerPage = new EventControllerPage(this.server, campID, this.matric);
                this.Hide();
                eventControllerPage.ShowDialog();
                this.Show();
                myEventListView.Items.Clear();
                myTaskListView.Items.Clear();
                studentEventManager.GetStudentEventsTasks(this.myEventListView, this.myTaskListView, matric);
                eventListView.Items.Clear();
                studentEventManager.GetEvents(this.eventListView);

                toolStripStatusLabel1.Text = "You have added <" + campName + "> to My Events.";
            }
        }

        private void button8_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void eventToolStripMenuItem_Click(object sender, EventArgs e) {
            createEvent();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void userManualToolStripMenuItem_Click(object sender, EventArgs e) {
            UserManualPage usermanual = new UserManualPage();
            usermanual.ShowDialog();
            dashBoardButtonDisable();
        }

        private void camphorV01ToolStripMenuItem_Click(object sender, EventArgs e) {
            AboutPage about = new AboutPage();
            about.ShowDialog();
            dashBoardButtonDisable();
        }

        private void seeDetailsButton_Click(object sender, EventArgs e) {
            EventDetailsManager eventDetailsManager = new EventDetailsManager(this.server);
            SeeEventDetailsPage seeDetailsPage;
            ListViewItem campEvent = eventListView.SelectedItems[0];
            int campID = Convert.ToInt32(campEvent.SubItems[3].Text);

            string eventName = eventDetailsManager.GetEventName(campID);
            string eventStartDate = eventDetailsManager.GetEventStartDate(campID);
            string eventEndDate = eventDetailsManager.GetEventEndDate(campID);
            string eventDescription = eventDetailsManager.GetEventDescription(campID);

            // check if student is already inside the event
            Event selectedEvent = server.GetEvent(campID);
            if (selectedEvent.SearchStudent(matric, 1) || selectedEvent.SearchStudent(matric, 2) || selectedEvent.SearchStudent(matric, 3)) {
                seeDetailsPage = new SeeEventDetailsPage(eventName, eventStartDate, eventStartDate, eventDescription, true);
                seeDetailsPage.ShowDialog();
            } else {
                seeDetailsPage = new SeeEventDetailsPage(eventName, eventStartDate, eventEndDate, eventDescription);
                seeDetailsPage.ShowDialog();
                if (seeDetailsPage.isJoin == true) {
                    eventDetailsManager.StudentJoinEvent(this.matric, campID, seeDetailsPage.role);
                    seeDetailsPage.Close();
                }
            }
            myEventListView.Items.Clear();
            myTaskListView.Items.Clear();
            studentEventManager.GetStudentEventsTasks(this.myEventListView, this.myTaskListView, matric);
            dashBoardButtonDisable();
        }

        private void button4_Click(object sender, EventArgs e) {
         //   SeeEventDetailsPage seedetails = new SeeEventDetailsPage();
         //   seedetails.Show();
            dashBoardButtonDisable();
        }

        private void viewEventButton_Click(object sender, EventArgs e) {
            ListViewItem campEvent = myEventListView.SelectedItems[0];
            string roleInWords = campEvent.SubItems[1].Text;
            int role = 0;
            int campID = Convert.ToInt32(campEvent.SubItems[2].Text);;

            if (roleInWords == "Organiser") role = 1;
            if (roleInWords == "Facilitator") role = 2;
            if (roleInWords == "Participant") role = 3;

            if (role == 3 || role == 2) { // if participant or facilitator
                EventDetailsManager eventDetailsManager = new EventDetailsManager(this.server);

                string eventName = eventDetailsManager.GetEventName(campID);
                string eventStartDate = eventDetailsManager.GetEventStartDate(campID);
                string eventEndDate = eventDetailsManager.GetEventEndDate(campID);
                string eventDescription = eventDetailsManager.GetEventDescription(campID);

                SeeEventDetailsPage seeDetailsPage = new SeeEventDetailsPage(eventName, eventStartDate, eventEndDate, eventDescription, true);
                seeDetailsPage.ShowDialog();
            } else {
                EventControllerPage eventControllerPage = new EventControllerPage(this.server, campID, this.matric);
                this.Hide();
                eventControllerPage.ShowDialog();
                this.Show();
                myEventListView.Items.Clear();
                myTaskListView.Items.Clear();
                studentEventManager.GetStudentEventsTasks(this.myEventListView, this.myTaskListView, matric);
                eventListView.Items.Clear();
                studentEventManager.GetEvents(this.eventListView);
            }

            dashBoardButtonDisable();
        }

        private void button2_Click(object sender, EventArgs e) {
            EditPersonalParticularsPage editparticulars = new EditPersonalParticularsPage(matric, studentEventManager.GetName(matric), studentEventManager.GetSchool(matric), studentEventManager.GetPassword(matric));
            editparticulars.ShowDialog();
            if (editparticulars.checkSave) {
                studentEventManager.ChangeStudentParticulars(matric, editparticulars.name, editparticulars.password);
                this.nameLabel.Text = editparticulars.name;
                toolStripStatusLabel1.Text = "Your particulars have been updated.";
            }
            dashBoardButtonDisable();
        }

        private void leaveEventButton_Click(object sender, EventArgs e) {
            ListViewItem campEvent = myEventListView.SelectedItems[0];
            Student student = server.GetStudent(this.matric);

            int campID = Convert.ToInt32(campEvent.SubItems[2].Text);
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            string campName = server.GetEvent(campID).name;
            string message = "Are you sure you want to leave <" + campName + ">?";
			string caption = "Leave Camp Event";
            result = MessageBox.Show(this, message, caption, buttons);

            if(result == DialogResult.Yes) {
                student.DeleteEvents(this.server, campID);
                campEvent.Remove();
                toolStripStatusLabel1.Text = "You have left <" + campName + ">.";
            }
            dashBoardButtonDisable();
        }

        private void myEventListview_SelectedIndexChanged(object sender, EventArgs e) {
            if (myEventListView.SelectedItems.Count > 0) {
                leaveEventButton.Enabled = true;
                viewEventButton.Enabled = true;
            } else {
                leaveEventButton.Enabled = false;
                viewEventButton.Enabled = false;
            }
        }

        private void eventListView_ColumnClick(object sender, ColumnClickEventArgs e) {
            // FUNCTION: Sort the ListView box
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 

            if (e.Column == 1 || e.Column == 2) {
                // Determine whether the column is the same as the last column clicked.
                if (e.Column != eventListViewSortColumnByDate) {
                    // Set the sort column to the new column.
                    eventListViewSortColumnByDate = e.Column;
                    // Set the sort order to ascending by default.
                    eventListView.Sorting = SortOrder.Ascending;
                } else {
                    // Determine what the last sort order was and change it.
                    if (eventListView.Sorting == SortOrder.Ascending)
                        eventListView.Sorting = SortOrder.Descending;
                    else
                        eventListView.Sorting = SortOrder.Ascending;
                } 
                this.eventListView.ListViewItemSorter = new ListViewItemComparerByDate(e.Column, eventListView.Sorting);
                // Call the sort method to manually sort.
                eventListView.Sort();
                // Set the ListViewItemSorter property to a new ListViewItemComparer
                // object.
            } else if (e.Column == 0) {
                // Determine whether the column is the same as the last column clicked.
                if (e.Column != eventListViewSortColumnByName) {
                    // Set the sort column to the new column.
                    eventListViewSortColumnByName = e.Column;
                    // Set the sort order to ascending by default.
                    eventListView.Sorting = SortOrder.Ascending;
                } else {
                    // Determine what the last sort order was and change it.
                    if (eventListView.Sorting == SortOrder.Ascending)
                        eventListView.Sorting = SortOrder.Descending;
                    else
                        eventListView.Sorting = SortOrder.Ascending;
                } 
                this.eventListView.ListViewItemSorter = new ListViewItemComparerByString(e.Column, eventListView.Sorting);
                // Call the sort method to manually sort.
                eventListView.Sort();
                // Set the ListViewItemSorter property to a new ListViewItemComparer
                // object.
            }
        }

        private void eventListView_SelectedIndexChanged(object sender, EventArgs e) {
            if (eventListView.SelectedItems.Count > 0) {
                seeDetailsButton.Enabled = true;
            } else {
                seeDetailsButton.Enabled = false;
            }
        }

        private void myEventListview_ColumnClick(object sender, ColumnClickEventArgs e) {
            if (e.Column != myEventListViewSortColumn) {
                // Set the sort column to the new column.
                myEventListViewSortColumn = e.Column;
                // Set the sort order to ascending by default.
                myEventListView.Sorting = SortOrder.Ascending;
            } else {
                // Determine what the last sort order was and change it.
                if (myEventListView.Sorting == SortOrder.Ascending)
                    myEventListView.Sorting = SortOrder.Descending;
                else
                    myEventListView.Sorting = SortOrder.Ascending;
            }

            this.myEventListView.ListViewItemSorter = new ListViewItemComparerByString(e.Column, myEventListView.Sorting);
            // Call the sort method to manually sort.
            myEventListView.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
        }

        private void myTaskListview_SelectedIndexChanged(object sender, EventArgs e) {
            if (myTaskListView.SelectedItems.Count > 0) {
                markAsDoneButton.Enabled = true;
                markAsUndoneButton.Enabled = true;
            } else {
                markAsDoneButton.Enabled = false;
                markAsUndoneButton.Enabled = false;
            }
        }

        private void myTaskListview_ColumnClick(object sender, ColumnClickEventArgs e) {
            if (e.Column != myTaskListViewSortColumn) {
                // Set the sort column to the new column.
                myTaskListViewSortColumn = e.Column;
                // Set the sort order to ascending by default.
                myTaskListView.Sorting = SortOrder.Ascending;
            } else {
                // Determine what the last sort order was and change it.
                if (myTaskListView.Sorting == SortOrder.Ascending)
                    myTaskListView.Sorting = SortOrder.Descending;
                else
                    myTaskListView.Sorting = SortOrder.Ascending;
            }

            this.myTaskListView.ListViewItemSorter = new ListViewItemComparerByString(e.Column, myTaskListView.Sorting);
            // Call the sort method to manually sort.
            myTaskListView.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
        }

        private void markAsDoneButton_Click (object sender, EventArgs e) {
            StudentEventManager studentEventManager = new StudentEventManager(this.server);

            foreach (ListViewItem item in myTaskListView.SelectedItems) {
                int campID = Convert.ToInt32(item.SubItems[1].Text);
                int taskID = Convert.ToInt32(item.SubItems[3].Text);

                if (item.SubItems[4].Text == "No") {
                    item.SubItems[4].Text = "Yes";
                    studentEventManager.EditTaskStatus(campID, taskID, true);
                }
            }
            toolStripStatusLabel1.Text = "Selected task(s) have been marked as done.";
            dashBoardButtonDisable();
        }

        private void markAsUndoneButton_Click(object sender, EventArgs e) {
            StudentEventManager studentEventManager = new StudentEventManager(this.server);
            
            foreach(ListViewItem item in myTaskListView.SelectedItems) {
                int campID = Convert.ToInt32(item.SubItems[1].Text);
                int taskID = Convert.ToInt32(item.SubItems[3].Text);

                if (item.SubItems[4].Text == "Yes") {
                    item.SubItems[4].Text = "No";
                    studentEventManager.EditTaskStatus(campID, taskID, false);
                }
                
            }
            toolStripStatusLabel1.Text = "Selected task(s) have been marked undone.";
            dashBoardButtonDisable();
        }

        private void dashBoardButtonDisable () {
            myTaskListView.SelectedItems.Clear();
            eventListView.SelectedItems.Clear();
            myEventListView.SelectedItems.Clear();
            markAsDoneButton.Enabled = false;
            markAsUndoneButton.Enabled = false;
            seeDetailsButton.Enabled = false;
            leaveEventButton.Enabled = false;
            viewEventButton.Enabled = false;
        }

        private void tabControl1_SelectedIndexChanged (object sender, EventArgs e) {
            dashBoardButtonDisable();
        }

    }
}
