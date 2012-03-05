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
    public partial class EventControllerPage : Form {
        Server server;
        int eventId;
        string matric;
        EventOrganizerManager eventOrganizerManager;
        public EventControllerPage (Server server, int eventId, string matric) {
            InitializeComponent();
            this.server = server;
            this.eventId = eventId;
            this.matric = matric;
            eventOrganizerManager = new EventOrganizerManager(server);
            this.publishCheckBox.Checked = server.GetEvent(eventId).published;

            //overall 
            this.campNameLabel.Text = eventOrganizerManager.GetEventName(eventId);
            this.startDateLabel.Text = eventOrganizerManager.GetEventStartDate(eventId);
            this.endDateLabel.Text = eventOrganizerManager.GetEventEndDate(eventId);
            this.organizersNoLabel.Text = eventOrganizerManager.GetManpowerCount(eventId, 1).ToString();
            this.facilitatorsNoLabel.Text = eventOrganizerManager.GetManpowerCount(eventId, 2).ToString();
            this.participantsNoLabel.Text = eventOrganizerManager.GetManpowerCount(eventId, 3).ToString();
            this.descriptionLabel.Text = eventOrganizerManager.GetEventDescription(eventId);

            //Program Tab
            this.programDateLabel.Text = this.startDateLabel.Text;
            if (this.startDateLabel.Text == this.endDateLabel.Text) {
                nextDayButton.Enabled = false;
            }

            eventOrganizerManager.GetProgramList(programListView, Convert.ToDateTime(this.startDateLabel.Text), this.eventId);

            //budget Tab
            this.totalIncomeLabel.Text = eventOrganizerManager.GetTotalIncome(eventId);
            this.totalExpenditureLabel.Text = eventOrganizerManager.GetTotalExpenditure(eventId);
            this.netCashflowLabel.Text = eventOrganizerManager.GetNetBudget(eventId);

            eventOrganizerManager.GetIncomeList(incomeListView, eventId);
            eventOrganizerManager.GetExpenditureList(expenditureListView, eventId);

            //logistic Tab
            eventOrganizerManager.GetLogsisticList(logisticListView, eventId);

            //Task Tab
            eventOrganizerManager.GetTaskList(taskListView, eventId);
            toolStripStatusLabel1.Text = "Welcome to the Event Manager for event <" + campNameLabel.Text + ">.";
        }
        
        private void editEventButton_Click (object sender, EventArgs e) {
            AddEventPage editEventPage = new AddEventPage(campNameLabel.Text, descriptionLabel.Text, Convert.ToDateTime(startDateLabel.Text), Convert.ToDateTime(endDateLabel.Text), Convert.ToDecimal(eventOrganizerManager.GetEventCampFees(eventId)));
            editEventPage.ShowDialog();

            if (editEventPage.isConfirm == true) {
                string campName = editEventPage.name;
                DateTime startDate = editEventPage.startDate;
                DateTime endDate = editEventPage.endDate;
                string description = editEventPage.description;
                decimal campFee = editEventPage.campFee;

                eventOrganizerManager.EditEvents(campName, startDate, endDate, description, campFee, eventId);
                this.campNameLabel.Text = campName;
                this.startDateLabel.Text = startDate.ToString("d");
                this.endDateLabel.Text = endDate.ToString("d");
                this.descriptionLabel.Text = description;
                toolStripStatusLabel1.Text = "The details for event <" + campNameLabel.Text + "> have been editted";
            }
        }

        private void exitButton_Click (object sender, EventArgs e) {
            this.Close();
        }

        private void editManpowerButton_Click (object sender, EventArgs e) {
            EditManpowerPage editManpowerPage = new EditManpowerPage(this.server, this.eventId, this.matric);
            editManpowerPage.ShowDialog();
            eventDetailsUpdate();
            programButtonCheck();
            toolStripStatusLabel1.Text = "Manpower details for the camp <" + campNameLabel.Text + "> have been updated.";
        }

        private void eventDetailsUpdate() {
            this.organizersNoLabel.Text = eventOrganizerManager.GetManpowerCount(eventId, 1).ToString();
            this.facilitatorsNoLabel.Text = eventOrganizerManager.GetManpowerCount(eventId, 2).ToString();
            this.participantsNoLabel.Text = eventOrganizerManager.GetManpowerCount(eventId, 3).ToString();
        }

        private void tabControl1_TabIndexChanged (object sender, EventArgs e) {
            if (tabControl1.SelectedTab == tabPage1) {
                programButtonDisable();
            } else if (tabControl1.SelectedTab == tabPage2) {
                budgetButtonDisable();
                this.totalIncomeLabel.Text = eventOrganizerManager.GetTotalIncome(eventId);
                this.totalExpenditureLabel.Text = eventOrganizerManager.GetTotalExpenditure(eventId);
                this.netCashflowLabel.Text = eventOrganizerManager.GetNetBudget(eventId);
                incomeListView.Items.Clear();
                expenditureListView.Items.Clear();
                eventOrganizerManager.GetIncomeList(incomeListView, eventId);
                eventOrganizerManager.GetExpenditureList(expenditureListView, eventId);
            } else if (tabControl1.SelectedTab == tabPage4) {
                taskButtonDisable();
            } else if (tabControl1.SelectedTab == tabPage3) {
                logisticButtonDisable();
            }

        }

        //Program
        private void programButtonCheck () {
            if (programListView.SelectedItems.Count == 1) {
                editProgramButton.Enabled = true;
            } else {
                editProgramButton.Enabled = false;
            }

            if (programListView.SelectedItems.Count > 0) {
                deleteProgramButton.Enabled = true;
            } else {
                deleteProgramButton.Enabled = false;
            }
        }

        private void programButtonDisable () {
            programListView.SelectedItems.Clear();
            editProgramButton.Enabled = false;
            deleteProgramButton.Enabled = false;
        }

        private void nextDayButton_Click (object sender, EventArgs e) {

            DateTime date = Convert.ToDateTime(programDateLabel.Text);
            date = date.AddDays(1);

            if (date.ToString("d") == this.endDateLabel.Text) {
                nextDayButton.Enabled = false;
            }
            previousDayButton.Enabled = true;
            programListView.Items.Clear();
            eventOrganizerManager.GetProgramList(programListView, date, this.eventId);
            this.programDateLabel.Text = date.ToString("d");
            this.dayTextBox.Text = (Convert.ToInt32(dayTextBox.Text) + 1).ToString();
            programButtonDisable();

        }

        private void previousDayButton_Click (object sender, EventArgs e) {
            DateTime date = Convert.ToDateTime(programDateLabel.Text);
            date = date.AddDays(-1);

            if (date.ToString("d") == this.startDateLabel.Text) {
                previousDayButton.Enabled = false;
            }
            nextDayButton.Enabled = true;
            programListView.Items.Clear();
            eventOrganizerManager.GetProgramList(programListView, date, this.eventId);
            this.programDateLabel.Text = date.ToString("d");

            this.dayTextBox.Text = (Convert.ToInt32(dayTextBox.Text) - 1).ToString();
            programButtonDisable();

        }

        private void addProgramButton_Click (object sender, EventArgs e) {
            AddProgramPage addPage = new AddProgramPage(Convert.ToDateTime(programDateLabel.Text).Date);
            addPage.ShowDialog();

            if (addPage.isConfirm == true) {
                string programName = addPage.name;
                DateTime startTime = addPage.startTime;
                DateTime endTime = addPage.endTime;
                string description = addPage.description;

                int programId = eventOrganizerManager.AddProgram(programName, startTime, endTime, description, this.eventId);

                // add list view
                ListViewItem newEvent = new ListViewItem(new[] { programName, description, startTime.Hour.ToString("D2") + ":00", startTime.Date != endTime.Date ? "24:00" : endTime.Hour.ToString("D2") + ":00", programId.ToString() });
                programListView.Items.Add(newEvent);
                toolStripStatusLabel1.Text = "Camp Program <" + programName + "> has been added.";
            }
            addPage.Close();
            programButtonDisable();
        }

        private void deleteProgramButton_Click (object sender, EventArgs e) {
            foreach (ListViewItem lvi in programListView.SelectedItems) {
                int programId = Convert.ToInt32(lvi.SubItems[4].Text);
                eventOrganizerManager.DeleteProgram(programId, this.eventId);
                lvi.Remove();

            }
            toolStripStatusLabel1.Text = "Selected camp program(s) have been deleted.";
            programButtonDisable();
        }

        private void editProgramButton_Click (object sender, EventArgs e) {

        }

        private void programListView_SelectedIndexChanged (object sender, EventArgs e) {
            programButtonCheck();
        }


        //Budget
        private void budgetButtonCheck () {
            if (tabControl2.SelectedTab == tabPage7) {
                if (expenditureListView.SelectedItems.Count == 1) {
                    editBudgetButton.Enabled = true;
                } else {
                    editBudgetButton.Enabled = false;
                }

                if (expenditureListView.SelectedItems.Count > 0) {
                    deleteBudgetButton.Enabled = true;
                } else {
                    deleteBudgetButton.Enabled = false;
                }
            } else {
                if (incomeListView.SelectedItems.Count == 1) {
                    editBudgetButton.Enabled = true;
                } else {
                    editBudgetButton.Enabled = false;
                }

                if (incomeListView.SelectedItems.Count > 0) {
                    deleteBudgetButton.Enabled = true;
                } else {
                    deleteBudgetButton.Enabled = false;
                }
            }

        }

        private void budgetButtonDisable () {
            expenditureListView.SelectedItems.Clear();
            incomeListView.SelectedItems.Clear();
            editBudgetButton.Enabled = false;
            deleteBudgetButton.Enabled = false;
        }

        private void addBudgetButton_Click (object sender, EventArgs e) {
            AddBudgetItemPage addPage = new AddBudgetItemPage();
            addPage.ShowDialog();

            if (addPage.isConfirm == true) {
                string budgetName = addPage.name;
                decimal amount = addPage.amount;

                if (tabControl2.SelectedTab == tabPage7) {
                    int budgetId = eventOrganizerManager.AddExpenditure(budgetName, amount, this.eventId);
                    ListViewItem newBudget = new ListViewItem(new[] { budgetName, amount.ToString("F2"), budgetId.ToString() });
                    expenditureListView.Items.Add(newBudget);
                } else {
                    int budgetId = eventOrganizerManager.AddIncome(budgetName, amount, this.eventId);
                    ListViewItem newBudget = new ListViewItem(new[] { budgetName, amount.ToString("F2"), budgetId.ToString() });
                    incomeListView.Items.Add(newBudget);
                }
                toolStripStatusLabel1.Text = "Budget item <" + budgetName + "> has been added to the list.";
            }
            addPage.Close();
            this.totalIncomeLabel.Text = eventOrganizerManager.GetTotalIncome(eventId);
            this.totalExpenditureLabel.Text = eventOrganizerManager.GetTotalExpenditure(eventId);
            this.netCashflowLabel.Text = eventOrganizerManager.GetNetBudget(eventId);
            budgetButtonDisable();
        }

        private void editBudgetButton_Click (object sender, EventArgs e) {
            if (tabControl2.SelectedTab == tabPage7) {
                ListViewItem lvi = expenditureListView.SelectedItems[0];
                if (lvi.SubItems[2].Text == "0") {
                    MessageBox.Show("Logistic List cannot be editted", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                } else {
                    AddBudgetItemPage editPage = new AddBudgetItemPage(lvi.SubItems[0].Text, Convert.ToDecimal(lvi.SubItems[1].Text));
                    editPage.ShowDialog();
                    if (editPage.isConfirm == true) {
                        string budgetName = editPage.name;
                        decimal amount = editPage.amount;
                        eventOrganizerManager.EditExpenditure(budgetName, amount, Convert.ToInt32(lvi.SubItems[2].Text), this.eventId);
                        lvi.SubItems[0].Text = budgetName;
                        lvi.SubItems[1].Text = amount.ToString("F2");
                        toolStripStatusLabel1.Text = "Budget item <" + budgetName + "> has been editted";
                    }
                }
            } else {
                ListViewItem lvi = incomeListView.SelectedItems[0];
                if (lvi.SubItems[2].Text == "0") {
                    MessageBox.Show("CampFees cannot be editted", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                } else {
                    AddBudgetItemPage editPage = new AddBudgetItemPage(lvi.SubItems[0].Text, Convert.ToDecimal(lvi.SubItems[1].Text));
                    editPage.ShowDialog();
                    if (editPage.isConfirm == true) {
                        string budgetName = editPage.name;
                        decimal amount = editPage.amount;
                        eventOrganizerManager.EditIncome(budgetName, amount, Convert.ToInt32(lvi.SubItems[2].Text), this.eventId);
                        lvi.SubItems[0].Text = budgetName;
                        lvi.SubItems[1].Text = amount.ToString("F2");
                        toolStripStatusLabel1.Text = "Budget item <" + budgetName + "> has been editted";
                    }
                }
            }
            this.totalIncomeLabel.Text = eventOrganizerManager.GetTotalIncome(eventId);
            this.totalExpenditureLabel.Text = eventOrganizerManager.GetTotalExpenditure(eventId);
            this.netCashflowLabel.Text = eventOrganizerManager.GetNetBudget(eventId);
            budgetButtonDisable();
        }

        private void deleteBudgetButton_Click (object sender, EventArgs e) {
            if (tabControl2.SelectedTab == tabPage7) {
                foreach (ListViewItem lvi in expenditureListView.SelectedItems) {
                    int budgetId = Convert.ToInt32(lvi.SubItems[2].Text);
                    if (budgetId != 0) {
                        eventOrganizerManager.DeleteExpenditure(budgetId, this.eventId);
                        lvi.Remove();
                    } else {
                        MessageBox.Show("Logistic List cannot be deleted", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            } else {
                foreach (ListViewItem lvi in incomeListView.SelectedItems) {
                    int budgetId = Convert.ToInt32(lvi.SubItems[2].Text);
                    if (budgetId != 0) {
                        eventOrganizerManager.DeleteIncome(budgetId, this.eventId);
                        lvi.Remove();
                    } else {
                        MessageBox.Show("CampFees cannot be deleted", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            toolStripStatusLabel1.Text = "Selected budget item(s) has been deleted";
            this.totalIncomeLabel.Text = eventOrganizerManager.GetTotalIncome(eventId);
            this.totalExpenditureLabel.Text = eventOrganizerManager.GetTotalExpenditure(eventId);
            this.netCashflowLabel.Text = eventOrganizerManager.GetNetBudget(eventId);
            budgetButtonDisable();
        }

        private void expenditureListView_SelectedIndexChanged (object sender, EventArgs e) {
            budgetButtonCheck();
        }

        private void incomeListView_SelectedIndexChanged (object sender, EventArgs e) {
            budgetButtonCheck();
        }

        private void tabControl2_SelectedIndexChanged (object sender, EventArgs e) {
            budgetButtonDisable();
        }

        //Tasks
        private void taskButtonCheck () {
            if (taskListView.SelectedItems.Count == 1) {
                editTaskButton.Enabled = true;
            } else {
                editTaskButton.Enabled = false;
            }

            if (taskListView.SelectedItems.Count > 0) {
                deleteTaskButton.Enabled = true;
            } else {
                deleteTaskButton.Enabled = false;
            }
        }

        private void taskButtonDisable () {
            taskListView.SelectedItems.Clear();
            editTaskButton.Enabled = false;
            deleteTaskButton.Enabled = false;
        }

        private void addTaskButton_Click (object sender, EventArgs e) {
            AddTaskPage addPage = new AddTaskPage(server, eventId);
            addPage.ShowDialog();

            if (addPage.isConfirm == true) {
                string name = addPage.name;
                DateTime deadline = addPage.deadline;
                string inChargeName = addPage.inChargeName;
                string inChargeMatric = addPage.matric;
                string description = addPage.description;

                int taskId = eventOrganizerManager.AddTask(name, inChargeMatric, description, deadline, false, 0, this.eventId);
                ListViewItem newTask = new ListViewItem(new[] { name, deadline.ToString("d"), inChargeMatric, inChargeName, description, "Overall", "0", taskId.ToString() });
                taskListView.Items.Add(newTask);
                toolStripStatusLabel1.Text = "Task <" + name + "> has been added to the tasklist.";
            }
            addPage.Close();
            taskButtonDisable();
        }

        private void editTaskButton_Click (object sender, EventArgs e) {
            ListViewItem lvi = taskListView.SelectedItems[0];
            AddTaskPage editPage = new AddTaskPage(lvi.SubItems[0].Text, lvi.SubItems[2].Text, lvi.SubItems[3].Text, Convert.ToDateTime(lvi.SubItems[1].Text), lvi.SubItems[4].Text, server, eventId);
            editPage.ShowDialog();

            if (editPage.isConfirm == true) {
                string name = editPage.name;
                DateTime deadline = editPage.deadline;
                string inChargeName = editPage.inChargeName;
                string inChargeMatric = editPage.matric;
                string description = editPage.description;

                eventOrganizerManager.EditTask(name, inChargeMatric, description, deadline, Convert.ToInt32(lvi.SubItems[6].Text), Convert.ToInt32(lvi.SubItems[7].Text), this.eventId);
                lvi.SubItems[0].Text = name;
                lvi.SubItems[1].Text = deadline.ToString("d");
                lvi.SubItems[2].Text = inChargeMatric;
                lvi.SubItems[3].Text = inChargeName;
                lvi.SubItems[4].Text = description;
                toolStripStatusLabel1.Text = "Details of task <" + name + "> has been editted.";
            }
            editPage.Close();
            taskButtonDisable();
        }


        private void deleteTaskButton_Click (object sender, EventArgs e) {
            foreach (ListViewItem lvi in taskListView.SelectedItems) {
                int taskId = Convert.ToInt32(lvi.SubItems[6].Text);
                eventOrganizerManager.DeleteTask(taskId, this.eventId);
                lvi.Remove();
            }
            toolStripStatusLabel1.Text = "Selected task(s) has been deleted.";
            taskButtonDisable();

        }

        private void taskListView_SelectedIndexChanged (object sender, EventArgs e) {
            taskButtonCheck();
        }

        //Logistic
        private void logisticButtonCheck () {
            if (logisticListView.SelectedItems.Count == 1) {
                editLogisticButton.Enabled = true;
            } else {
                editLogisticButton.Enabled = false;
            }

            if (logisticListView.SelectedItems.Count > 0) {
                deleteLogisticButton.Enabled = true;
            } else {
                deleteLogisticButton.Enabled = false;
            }
        }

        private void logisticButtonDisable () {
            logisticListView.SelectedItems.Clear();
            editLogisticButton.Enabled = false;
            deleteLogisticButton.Enabled = false;
        }

        private void addLogisticButton_Click (object sender, EventArgs e) {
            AddLogisticsItemPage addPage = new AddLogisticsItemPage();
            addPage.ShowDialog();

            if (addPage.isConfirm == true) {
                string name = addPage.name;
                decimal amount = addPage.amount;
                int quantity = addPage.quantity;
                string description = addPage.description;

                int logisticId = eventOrganizerManager.AddLogistic(name, description, amount, quantity, 0, this.eventId);
                ListViewItem newLogistic = new ListViewItem(new[] { name, amount.ToString("F2"), quantity.ToString(), description, "Overall", "0", logisticId.ToString() });
                logisticListView.Items.Add(newLogistic);
                toolStripStatusLabel1.Text = "Logistic item <" + name + "> has been added to the logistics list.";
            }
            logisticButtonDisable();
        }

        private void editLogisticButton_Click (object sender, EventArgs e) {
            ListViewItem lvi = logisticListView.SelectedItems[0];
            AddLogisticsItemPage editPage = new AddLogisticsItemPage(lvi.SubItems[0].Text, Convert.ToDecimal(lvi.SubItems[1].Text), Convert.ToInt32(lvi.SubItems[2].Text), lvi.SubItems[3].Text);
            editPage.ShowDialog();

            if (editPage.isConfirm == true) {
                string name = editPage.name;
                decimal amount = editPage.amount;
                int quantity = editPage.quantity;
                string description = editPage.description;

                eventOrganizerManager.EditLogistic(name, description, amount, quantity, Convert.ToInt32(lvi.SubItems[5].Text), Convert.ToInt32(lvi.SubItems[6].Text), this.eventId);
                lvi.SubItems[0].Text = name;
                lvi.SubItems[1].Text = amount.ToString("F2");
                lvi.SubItems[2].Text = quantity.ToString();
                lvi.SubItems[3].Text = description;
                toolStripStatusLabel1.Text = "Details of logistic item <" + name + "> has been editted.";
            }
            taskButtonDisable();
        }

        private void deleteLogisticButton_Click (object sender, EventArgs e) {
            foreach (ListViewItem lvi in logisticListView.SelectedItems) {
                int logisticId = Convert.ToInt32(lvi.SubItems[6].Text);
                eventOrganizerManager.DeleteLogistic(logisticId, this.eventId);
                lvi.Remove();
            }
            toolStripStatusLabel1.Text = "Selected logistics item(s) has been deleted.";
            taskButtonDisable();

        }

        private void logisticListView_SelectedIndexChanged (object sender, EventArgs e) {
            logisticButtonCheck();
        }


        //publish
        private void publishCheckBox_CheckedChanged (object sender, EventArgs e) {
            eventOrganizerManager.PublishEvents(publishCheckBox.Checked, eventId);
            if (publishCheckBox.Checked == true) {
                toolStripStatusLabel1.Text = "Your event is now made available for the public to view and join";
            } else {
                toolStripStatusLabel1.Text = "Your event is now made private. The public cannot view and join your event";
            }
        }




    }
}







