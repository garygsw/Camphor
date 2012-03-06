using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Camphor.Model {
    [Serializable]
    public class Server {
        //key is the matric of the student

        public Server () {
            adminPassword = "SBTK"; // default password
        }

        private Dictionary<string, Student> studentList = new Dictionary<string, Student>();

        //key is the eventId
        private Dictionary<int, Event> eventList = new Dictionary<int, Event>();

        private int eventId = 1;
        public string adminPassword { get; set; }

        // eventLists add/edit/delete
        public void AddEvent (Event newEvent) {
            // FUNCTION: Add new event to the list
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            newEvent.eventId = this.eventId++;
            eventList.Add(newEvent.eventId, newEvent);
        }

        public Event GetEvent (int id) {
            // FUNCTION: search for the event to be returned 
            // PRE-CONDITIONS: id must be valid
            // POST-CONDITIONS: return the reference of the task
            return eventList[id];
        }

        public void GetEventList (ListView lv) {
            ListViewItem lvi;
            foreach (KeyValuePair<int, Event> kvp in eventList) {
                if (kvp.Value.published) {
                    lvi = new ListViewItem(new[] { kvp.Value.name, kvp.Value.startDate.ToString("d"), kvp.Value.endDate.ToString("d"), Convert.ToString(kvp.Key) });
                    lv.Items.Add(lvi);
                }
            }
        }

        public void DeleteEvent (int id) {
            // FUNCTION: delete for the event to be returned 
            // PRE-CONDITIONS: id must be valid
            // POST-CONDITIONS: 
            eventList.Remove(id);
        }

        // studentLists add/edit/delete
        public void AddStudent (Student newStudent) {
            // FUNCTION: Add new Student to the list
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            studentList.Add(newStudent.matric, newStudent);
        }

        public Student GetStudent (string matric) {
            // FUNCTION: search for the Student to be returned 
            // PRE-CONDITIONS: matric must be valid
            // POST-CONDITIONS: return the reference of the task
            return studentList[matric];
        }

        public void DeleteStudent (string matric) {
            // FUNCTION: delete for the Student to be returned 
            // PRE-CONDITIONS: matric must be valid
            // POST-CONDITIONS: 
            Student student = studentList[matric];
            student.DeleteEvents(this);
            studentList.Remove(matric);
        }

        public void GetStudentList (ListView studentList, bool passwordInclude) {
            if (passwordInclude) {
                foreach (KeyValuePair<string, Student> kvp in this.studentList) {
                    ListViewItem lvi = new ListViewItem(new[] { kvp.Value.name, kvp.Value.gender.ToString(), kvp.Value.matric, kvp.Value.password, kvp.Value.school });
                    studentList.Items.Add(lvi);
                }
            } else {
                foreach (KeyValuePair<string, Student> kvp in this.studentList) {
                    ListViewItem lvi = new ListViewItem(new[] { kvp.Value.name, kvp.Value.matric, kvp.Value.school });
                    studentList.Items.Add(lvi);
                }
            }
        }

        public bool SearchStudent(string matric) {
            if (studentList.ContainsKey(matric)) {
                return true;
            } else {
                return false;
            }
        }
    }
}
