using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Camphor.Model;
using Camphor.View;

namespace Camphor.Controller {
    class StudentEventManager : StudentParticularsManager {

        public StudentEventManager (Server server) {
            this.server = server;
        }

        protected StudentEventManager () { }

        public void GetStudentEventsTasks (ListView eventListview, ListView taskListview, string matric) {
            Student student = server.GetStudent(matric);
            student.GetEventTaskList(eventListview, taskListview, server);
        }

        public void GetEvents (ListView allEventListview) {
            server.GetEventList(allEventListview);
        }

        public int AddEvents (string name, DateTime startDate, DateTime endDate, string description, decimal amount) {
            Event newEvent = new Event();
            newEvent.name = name;
            newEvent.startDate = startDate;
            newEvent.endDate = endDate;
            newEvent.description = description;
            newEvent.campFees = amount;
            newEvent.published = false;
            server.AddEvent(newEvent);

            return newEvent.eventId;
        }

        public void EditTaskStatus (int eventID, int taskID, bool done) {
            Event campEvent = server.GetEvent(eventID);
            Task task = campEvent.EditTask(taskID);

            if (done) {
                task.complete = true;
            } else {
                task.complete = false;
            }
        }
    }
}
