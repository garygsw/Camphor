using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Camphor.Model {
    [Serializable]
    public class Event {

        // FUNCTION: Get/Set methods for all variables
        public int eventId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public bool published { get; set; }
        private int programId = 1;
        private int taskId = 1;
        private int incomeId = 1;
        private int expenditureId = 1;
        private int logisticId = 1;
        public decimal campFees { get; set; }


        //list of tasks/programs/manpower/budget
        private List<Task> taskList = new List<Task>();
        private List<Programs> programList = new List<Programs>();

        private Dictionary<string, bool> organizerList = new Dictionary<string, bool>();
        private Dictionary<string, bool> facilitatorList = new Dictionary<string, bool>();
        private Dictionary<string, bool> participantList = new Dictionary<string, bool>();
        private List<Budget> incomeList = new List<Budget>();
        private List<Budget> expenditureList = new List<Budget>();
        private List<Logistic> logisticList = new List<Logistic>();





        // taskLists add/edit/delete
        public void AddTask (Task newTask) {
            // FUNCTION: Add new task to the list
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            newTask.taskId = this.taskId++;
            taskList.Add(newTask);
        }

        public Task EditTask (int id) {
            // FUNCTION: search for the task to be returned 
            // PRE-CONDITIONS: id must be valid
            // POST-CONDITIONS: return the reference of the task
            return taskList.Find(delegate(Task T) { return T.taskId == id; });
        }

        public void GetTask (ListView taskListview, string matric) {
            ListViewItem lvi;
            foreach (Task task in taskList) {
                if (task.inCharge == matric) {
                    lvi = new ListViewItem(new[] { this.name, Convert.ToString(this.eventId), task.name, Convert.ToString(task.taskId), task.complete ? "Yes" : "No" });
                    taskListview.Items.Add(lvi);
                }
            }
        }

        public void GetTask (ListView taskListview,Server server) {
            ListViewItem lvi;
            foreach (Task task in taskList) {
                lvi = new ListViewItem(new[] { task.name, task.deadline.ToString("d"), task.inCharge, server.GetStudent(task.inCharge).name, task.description, task.programId == 0 ? "Overall" : EditProgram(task.programId).name, Convert.ToString(task.programId), Convert.ToString(task.taskId) });
                taskListview.Items.Add(lvi);
            }
        }



        public void DeleteTask (int id) {
            // FUNCTION: delete for the task to be returned 
            // PRE-CONDITIONS: id must be valid
            // POST-CONDITIONS: 
            taskList.Remove(taskList.Find(delegate(Task T) { return T.taskId == id; }));
        }

        //programLists add/delete/edit 
        public void AddProgram (Programs newProgram) {
            // FUNCTION: Add new program to the list
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            newProgram.programId = this.programId++;
            programList.Add(newProgram);
        }

        public Programs EditProgram (int id) {
            // FUNCTION: search for the program to be returned 
            // PRE-CONDITIONS: id must be valid
            // POST-CONDITIONS: return the reference of the program
            return programList.Find(delegate(Programs P) { return P.programId == id; });

        }

        public void DeleteProgram (int id) {
            // FUNCTION: delete for the program and all task associate with the program
            // PRE-CONDITIONS: id must be valid
            // POST-CONDITIONS: 
            foreach (Task task in taskList) {
                if (task.programId == id) {
                    taskList.Remove(task);
                }
            }

            foreach (Logistic logistic in logisticList) {
                if (logistic.programId == id) {
                    logisticList.Remove(logistic);
                }
            }

            programList.Remove(programList.Find(delegate(Programs P) { return P.programId == id; }));
        }

        public void GetProgram (ListView programListview, DateTime day) {
            ListViewItem lvi;
            foreach (Programs program in programList) {
                if (day.Date == program.startTime.Date) {
                    lvi = new ListViewItem(new[] { program.name, program.description, program.startTime.Hour.ToString("D2") + ":00", program.startTime.Date != program.endTime.Date ? "24:00" : program.endTime.Hour.ToString("D2") + ":00", Convert.ToString(program.programId) });
                    programListview.Items.Add(lvi);
                }
            }
        }

        //BudgetLists add/delete/edit 
        public void AddIncome (Budget newBudget) {
            // FUNCTION: Add new income to the list
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            newBudget.budgetId = this.incomeId++;
            incomeList.Add(newBudget);
        }

        public Budget EditIncome (int id) {
            // FUNCTION: search for the income to be returned 
            // PRE-CONDITIONS: id must be valid
            // POST-CONDITIONS: return the reference of the income
            return incomeList.Find(delegate(Budget B) { return B.budgetId == id; });

        }

        public void DeleteIncome (int id) {
            // FUNCTION: delete for the income to be returned 
            // PRE-CONDITIONS: id must be valid
            // POST-CONDITIONS: 
            incomeList.Remove(incomeList.Find(delegate(Budget B) { return B.budgetId == id; }));
        }

        public void GetIncome (ListView incomeListView) {
            ListViewItem lvi;
            foreach (Budget income in incomeList) {
                lvi = new ListViewItem(new[] { income.description, income.amount.ToString("F2"), Convert.ToString(income.budgetId) });
                incomeListView.Items.Add(lvi);
            }
            lvi = new ListViewItem(new[] { "Camp Fees", GetPatricipantFeeIncome().ToString("F2"), "0" });
            incomeListView.Items.Add(lvi);
        }

        public decimal GetTotalIncome () {
            decimal amount = 0;
            foreach (Budget income in incomeList) {
                amount += income.amount;
            }
            amount += GetPatricipantFeeIncome();
            return amount;
        }


        private decimal GetPatricipantFeeIncome () {
            decimal amount = 0;
            int number = 0;
            foreach (KeyValuePair<string, bool> kvp in organizerList) {
                if (kvp.Value) {
                    number++;
                }
            }

            foreach (KeyValuePair<string, bool> kvp in participantList) {
                if (kvp.Value) {
                    number++;
                }
            }

            foreach (KeyValuePair<string, bool> kvp in facilitatorList) {
                if (kvp.Value) {
                    number ++ ;
                }
            }
                    
            amount = number * this.campFees;
            return amount;
        }

        public void AddExpenditure (Budget newBudget) {
            // FUNCTION: Add new expenditure to the list
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            newBudget.budgetId = this.expenditureId++;
            expenditureList.Add(newBudget);
        }

        public Budget EditExpenditure (int id) {
            // FUNCTION: search for the expenditure to be returned 
            // PRE-CONDITIONS: id must be valid
            // POST-CONDITIONS: return the reference of the expenditure
            return expenditureList.Find(delegate(Budget B) { return B.budgetId == id; });

        }

        public void DeleteExpenditure (int id) {
            // FUNCTION: delete for the expenditure to be returned 
            // PRE-CONDITIONS: id must be valid
            // POST-CONDITIONS: 
            expenditureList.Remove(expenditureList.Find(delegate(Budget B) { return B.budgetId == id; }));
        }

        public void GetExpenditure (ListView expenditureListView) {
            ListViewItem lvi;
            foreach (Budget expenditure in expenditureList) {
                lvi = new ListViewItem(new[] { expenditure.description, expenditure.amount.ToString("F2"), Convert.ToString(expenditure.budgetId) });
                expenditureListView.Items.Add(lvi);
            }
            lvi = new ListViewItem(new[] { "Logistics", GetLogisticExpenditure().ToString("F2"), "0" });
            expenditureListView.Items.Add(lvi);
        }

        public decimal GetTotalExpenditure () {
            decimal amount = 0;
            foreach (Budget expenditure in expenditureList) {
                amount += expenditure.amount;
            }
            amount += GetLogisticExpenditure();
            return amount;
        }

        private decimal GetLogisticExpenditure () {
            decimal amount = 0;
            foreach (Logistic logistic in logisticList) {
                amount += logistic.amount * logistic.quantity;
            }
            return amount;
        }


        //LogisticLists add/delete/edit 
        public void AddLogistic (Logistic newLogistic) {
            // FUNCTION: Add new logistic to the list
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            newLogistic.logisticId = this.logisticId++;
            logisticList.Add(newLogistic);
        }

        public Logistic EditLogistic (int id) {
            // FUNCTION: search for the logistic to be returned 
            // PRE-CONDITIONS: id must be valid
            // POST-CONDITIONS: return the reference of the income
            return logisticList.Find(delegate(Logistic L) { return L.logisticId == id; });

        }

        public void DeleteLogistic (int id) {
            // FUNCTION: delete for the logistic to be returned 
            // PRE-CONDITIONS: id must be valid
            // POST-CONDITIONS: 
            logisticList.Remove(logisticList.Find(delegate(Logistic L) { return L.logisticId == id; }));
        }

        public void GetLogistic (ListView logisticListView) {
            ListViewItem lvi;
            foreach (Logistic logistic in logisticList) {
                lvi = new ListViewItem(new[] { logistic.name, logistic.amount.ToString("F2"), Convert.ToString(logistic.quantity), logistic.description, logistic.programId == 0 ? "Overall" : EditProgram(logistic.programId).name, Convert.ToString(logistic.programId), Convert.ToString(logistic.logisticId) });
                logisticListView.Items.Add(lvi);
            }

        }


        //Manpower add/delete
        public void AddOrganiser (string newOrganizer, bool checkPaid) {
            // FUNCTION: Add new organizer to the list
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            organizerList.Add(newOrganizer, checkPaid);
        }

        public void EditOrganiser (string organizer, bool checkPaid) {
            // FUNCTION: Edit organizer in the list
            // PRE-CONDITIONS: organizer id must be valid
            // POST-CONDITIONS: 
            organizerList[organizer] = checkPaid;
        }

        public void DeleteOrganiser (string organizer, Server server) {
            // FUNCTION: delete for the organizer to be returned 
            // PRE-CONDITIONS: organizer id must be valid
            // POST-CONDITIONS: if no more Organiser left delete the whole event
            organizerList.Remove(organizer);
            if (organizerList.Count == 0) {
                foreach (KeyValuePair<string, bool> kvp in facilitatorList) {
                    server.GetStudent(kvp.Key).DeleteEvents(server, eventId);
                }
                foreach (KeyValuePair<string, bool> kvp in participantList) {
                    server.GetStudent(kvp.Key).DeleteEvents(server, eventId);
                }
                server.DeleteEvent(eventId);
            }
        }

        public void AddFacilitator (string newFacilitator, bool checkPaid) {
            // FUNCTION: Add new facilitator to the list
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            facilitatorList.Add(newFacilitator, checkPaid);
        }

        public void EditFacilitator (string facilitator, bool checkPaid) {
            // FUNCTION: Edit facilitator in the list
            // PRE-CONDITIONS: facilitator id must be valid
            // POST-CONDITIONS: 
            facilitatorList[facilitator] = checkPaid;
        }

        public void DeleteFacilitator (string facilitator) {
            // FUNCTION: delete for the facilitator to be returned 
            // PRE-CONDITIONS: facilitator id must be valid
            // POST-CONDITIONS: 
            facilitatorList.Remove(facilitator);
        }

        public void AddParticipant (string newParticipant, bool checkPaid) {
            // FUNCTION: Add new participant to the list
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            participantList.Add(newParticipant, checkPaid);
        }

        public void EditParticipant (string participant, bool checkPaid) {
            // FUNCTION: Edit participant in the list
            // PRE-CONDITIONS: participant id must be valid
            // POST-CONDITIONS: 
            participantList[participant] = checkPaid;
        }

        public void DeleteParticipant (string participant) {
            // FUNCTION: delete for the participant to be returned 
            // PRE-CONDITIONS: participant id must be valid
            // POST-CONDITIONS: 
            participantList.Remove(participant);
        }

        public bool SearchStudent (string matric, int role) {
            if (role == 1) return organizerList.ContainsKey(matric);
            else if (role == 2) return facilitatorList.ContainsKey(matric);
            else return participantList.ContainsKey(matric);
        }

        public int GetManpowerCount (int type) {
            //1 for organizer, 2 for facilitators, 3 for participants
            if (type == 1) return organizerList.Count;
            else if (type == 2) return facilitatorList.Count;
            else return participantList.Count;
        }

        public void GetOrganiserList (ListView organiserListView, Server server) {
            ListViewItem lvi;
            Student student;
            foreach (KeyValuePair<string, bool> kvp in organizerList) {
                student = server.GetStudent(kvp.Key);
                lvi = new ListViewItem(new[] { student.name, kvp.Key, kvp.Value ? "Yes" : "No" });
                organiserListView.Items.Add(lvi);
            }
        }

        public void GetFacilitatorList (ListView facilitatorListView, Server server) {
            ListViewItem lvi;
            Student student;
            foreach (KeyValuePair<string, bool> kvp in facilitatorList) {
                student = server.GetStudent(kvp.Key);
                lvi = new ListViewItem(new[] { student.name, kvp.Key, kvp.Value ? "Yes" : "No" });
                facilitatorListView.Items.Add(lvi);
            }
        }

        public void GetParticipantList (ListView participantListView, Server server) {
            ListViewItem lvi;
            Student student;
            foreach (KeyValuePair<string, bool> kvp in facilitatorList) {
                student = server.GetStudent(kvp.Key);
                lvi = new ListViewItem(new[] { student.name, kvp.Key, kvp.Value ? "Yes" : "No" });
                participantListView.Items.Add(lvi);
            }
        }

    }
}
