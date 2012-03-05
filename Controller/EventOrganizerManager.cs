using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Camphor.Model;
using Camphor.View;
using System.Windows.Forms;

namespace Camphor.Controller {
    class EventOrganizerManager : EventProgramManager{

        public EventOrganizerManager (Server server) {
            this.server = server;
        }

        //Logistics manager
        public void GetLogsisticList (ListView logisticLv, int eventId) {
            // FUNCTION: get the list of events
            // PRE-CONDITIONS: 
            // POST-CONDITIONS:
            server.GetEvent(eventId).GetLogistic(logisticLv);
        }

        public int AddLogistic (string name, string description, decimal amount, int quantity, int programId, int eventId) {
            // FUNCTION: Add a new logistic
            // PRE-CONDITIONS: 
            // POST-CONDITIONS:
            Logistic logistic = new Logistic();
            logistic.name = name;
            logistic.description = description;
            logistic.amount = amount;
            logistic.quantity = quantity;
            logistic.programId = programId;
            server.GetEvent(eventId).AddLogistic(logistic);

            return logistic.logisticId;
        }

        public void EditLogistic (string name, string description, decimal amount, int quantity, int programId, int logisticId, int eventId) {
            // FUNCTION: Edit a new logistic
            // PRE-CONDITIONS: 
            // POST-CONDITIONS:
            Logistic logistic = server.GetEvent(eventId).EditLogistic(logisticId);
            logistic.name = name;
            logistic.description = description;
            logistic.amount = amount;
            logistic.quantity = quantity;
            logistic.programId = programId;
        }

        public void DeleteLogistic (int logisticId, int eventId) {
            // FUNCTION: Edit a new logistic
            // PRE-CONDITIONS: 
            // POST-CONDITIONS:
           server.GetEvent(eventId).DeleteLogistic(logisticId);
        }

        //Task Manager
        public void GetTaskList (ListView taskLv, int eventId) {
            // FUNCTION: get the list of task
            // PRE-CONDITIONS: 
            // POST-CONDITIONS:
            server.GetEvent(eventId).GetTask(taskLv,server);
        }

        public int AddTask (string name, string inCharge, string description, DateTime deadline, bool complete, int programId, int eventId) {
            // FUNCTION: Add a new task
            // PRE-CONDITIONS: 
            // POST-CONDITIONS:
            Task task = new Task();
            task.name = name;
            task.inCharge = inCharge;
            task.description = description;
            task.deadline = deadline;
            task.programId = programId;
            task.complete = complete;
            server.GetEvent(eventId).AddTask(task);

            return task.taskId;
        }

        public void EditTask (string name, string inCharge, string description, DateTime deadline, int programId, int taskId, int eventId) {
            // FUNCTION: Edit a new task
            // PRE-CONDITIONS: 
            // POST-CONDITIONS:
            Task task = server.GetEvent(eventId).EditTask(taskId);
            task.name = name;
            task.inCharge = inCharge;
            task.description = description;
            task.deadline = deadline;
            task.programId = programId;
        }

        public void DeleteTask (int taskId, int eventId) {
            // FUNCTION: Edit a new logistic
            // PRE-CONDITIONS: 
            // POST-CONDITIONS:
            server.GetEvent(eventId).DeleteTask(taskId);
        }

        //Expenditure manager
        public void GetExpenditureList (ListView expenditureLv, int eventId) {
            // FUNCTION: get the list of expenditure
            // PRE-CONDITIONS: 
            // POST-CONDITIONS:
            server.GetEvent(eventId).GetExpenditure(expenditureLv);
        }

        public int AddExpenditure (string name, decimal amount, int eventId) {
            // FUNCTION: Add a new expenditure
            // PRE-CONDITIONS: 
            // POST-CONDITIONS:
            Budget budget = new Budget();
            budget.description = name;
            budget.amount = amount;
            server.GetEvent(eventId).AddExpenditure(budget);

            return budget.budgetId;
        }

        public void EditExpenditure (string name, decimal amount, int budgetId, int eventId) {
            // FUNCTION: Edit a new expenditure
            // PRE-CONDITIONS: 
            // POST-CONDITIONS:
            Budget budget = server.GetEvent(eventId).EditExpenditure(budgetId);
            budget.description = name;
            budget.amount = amount;
        }

        public void DeleteExpenditure (int budgetId, int eventId) {
            // FUNCTION: Delete a expenditure
            // PRE-CONDITIONS: 
            // POST-CONDITIONS:
            server.GetEvent(eventId).DeleteExpenditure(budgetId);
        }

        public string GetTotalExpenditure (int eventId) {
            // FUNCTION: get total expenditure
            // PRE-CONDITIONS: 
            // POST-CONDITIONS:
            return server.GetEvent(eventId).GetTotalExpenditure().ToString("F2");
        }

        //income manager

        public void GetIncomeList (ListView incomeLv, int eventId) {
            // FUNCTION: get the list of expenditure
            // PRE-CONDITIONS: 
            // POST-CONDITIONS:
            server.GetEvent(eventId).GetIncome(incomeLv);
        }

        public int AddIncome (string name, decimal amount, int eventId) {
            // FUNCTION: Add a new expenditure
            // PRE-CONDITIONS: 
            // POST-CONDITIONS:
            Budget budget = new Budget();
            budget.description = name;
            budget.amount = amount;
            server.GetEvent(eventId).AddIncome(budget);
            return budget.budgetId;
        }

        public void EditIncome (string name, decimal amount, int budgetId, int eventId) {
            // FUNCTION: Edit a new expenditure
            // PRE-CONDITIONS: 
            // POST-CONDITIONS:
            Budget budget = server.GetEvent(eventId).EditIncome(budgetId);
            budget.description = name;
            budget.amount = amount;
        }

        public void DeleteIncome (int budgetId, int eventId) {
            // FUNCTION: Delete a expenditure
            // PRE-CONDITIONS: 
            // POST-CONDITIONS:
            server.GetEvent(eventId).DeleteIncome(budgetId);
        }

        public string GetTotalIncome (int eventId) {
            // FUNCTION: get total income
            // PRE-CONDITIONS: 
            // POST-CONDITIONS:
            return server.GetEvent(eventId).GetTotalIncome().ToString("F2");
        }

        public string GetNetBudget (int eventId) {
            // FUNCTION: get net budget
            // PRE-CONDITIONS: 
            // POST-CONDITIONS:
            Event events = server.GetEvent(eventId);
            decimal netBudget = events.GetTotalIncome() - events.GetTotalExpenditure();
            return netBudget.ToString("F2");
        }

        //program manager

        public void GetProgramList (ListView programLv, DateTime day, int eventId) {
            // FUNCTION: get the list of program
            // PRE-CONDITIONS: 
            // POST-CONDITIONS:
            server.GetEvent(eventId).GetProgram(programLv, day);
        }

        public int AddProgram (string name, DateTime startTime, DateTime endTime, string description, int eventId) {
            // FUNCTION: Add a new program
            // PRE-CONDITIONS: 
            // POST-CONDITIONS:
            Programs program = new Programs();
            program.description = description;
            program.name = name;
            program.startTime = startTime;
            program.endTime = endTime;
            server.GetEvent(eventId).AddProgram(program);

            return program.programId;
        }

        public void DeleteProgram (int programId, int eventId) {
            // FUNCTION: Delete a program
            // PRE-CONDITIONS: 
            // POST-CONDITIONS:
            server.GetEvent(eventId).DeleteProgram(programId);
        }

        // manpower manager 
        public int GetManpowerCount (int eventId, int type) {
            return server.GetEvent(eventId).GetManpowerCount(type);
        }

        //event manager
        public void EditEvents (string name, DateTime startDate, DateTime endDate, string description, decimal amount, int eventId) {
            Event editEvent = server.GetEvent(eventId);
            editEvent.name = name;
            editEvent.startDate = startDate;
            editEvent.endDate = endDate;
            editEvent.description = description;
            editEvent.campFees = amount;

        }

        public void PublishEvents (bool published, int eventId) {
            server.GetEvent(eventId).published = published;
        }

    }
}
