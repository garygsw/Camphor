using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Camphor.Model {
    [Serializable]
    public class Student {

        // FUNCTION: Get/Set methods for all variables
        public string name { get; set; }
        public string password { get; set; }
        public string matric { get; set; }
        public string school { get; set; }
        public Gender gender { get; set; }

        // key - int for eventId
        // value - int 1 for organizer, 2 for facilitator, 3 for participant 
        private Dictionary<int, int> eventsList = new Dictionary<int, int>();

        public void GetEventTaskList (ListView eventListview, ListView taskListview, Server server) {
            ListViewItem lvi;
            foreach (KeyValuePair<int, int> kvp in eventsList) {
                if (kvp.Value == 1) {
                    lvi = new ListViewItem(new[] { server.GetEvent(kvp.Key).name, "Organiser", Convert.ToString(kvp.Key) });
                    Event events = server.GetEvent(Convert.ToInt32(lvi.SubItems[2].Text));
                    events.GetTask(taskListview, matric);
                } else if (kvp.Value == 2) {
                    lvi = new ListViewItem(new[] { server.GetEvent(kvp.Key).name, "Facilitator", Convert.ToString(kvp.Key) });
                    Event events = server.GetEvent(Convert.ToInt32(lvi.SubItems[2].Text));
                    events.GetTask(taskListview, matric);
                } else {
                    lvi = new ListViewItem(new[] { server.GetEvent(kvp.Key).name, "Participant", Convert.ToString(kvp.Key) });
                }
                eventListview.Items.Add(lvi);
            }
        }

        public void AddEvents (Server server, int id, int role) {
            // FUNCTION: add event with particular Id
            // PRE-CONDITIONS: assuming id exist
            // POST-CONDITIONS:
            eventsList.Add(id, role);
            Event events = server.GetEvent(id);
            if (role == 1) events.AddOrganiser(matric,false);
            else if (role == 2) events.AddFacilitator(matric,false);
            else events.AddParticipant(matric,false);
        }

        public void DeleteEvents (Server server, int id) {
            // FUNCTION: delete event with particular Id
            // PRE-CONDITIONS: assuming id exist
            // POST-CONDITIONS:
            Event events = server.GetEvent(id);
            if (eventsList[id] == 1) events.DeleteOrganiser(matric,server);
            else if (eventsList[id] == 2) events.DeleteFacilitator(matric);
            else events.DeleteParticipant(matric);

            eventsList.Remove(id);
        }

        public void DeleteEvents (Server server) {
            // FUNCTION: delete all event the student have, for deleting the student
            // PRE-CONDITIONS: assuming id exist
            // POST-CONDITIONS:
            Event events;
            foreach (KeyValuePair<int, int> kvp in eventsList) {
                events = server.GetEvent(kvp.Key);
                if (kvp.Value == 1) events.DeleteOrganiser(matric,server);
                else if (kvp.Value == 2) events.DeleteFacilitator(matric);
                else events.DeleteParticipant(matric);
            }

        }
    }
}
