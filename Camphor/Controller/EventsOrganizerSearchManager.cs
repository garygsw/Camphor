using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Camphor.Model;
using Camphor.View;

namespace Camphor.Controller {
    class EventsOrganizerSearchManager {
        Server server;

        public EventsOrganizerSearchManager (Server server) {
            this.server = server;
        }

        public string SearchName (string matric) {
            // search within entire server
            Student student = server.GetStudent(matric);
            if (!server.SearchStudent(matric)) {
                return "";
            } else {
                return student.name;
            }
        }

        public string SearchNameWithinEvent (string matric, int eventId) {
            bool containsMatric = false;
            containsMatric = server.GetEvent(eventId).SearchStudent(matric, 1);
            if (!containsMatric) {
                containsMatric = server.GetEvent(eventId).SearchStudent(matric, 2);
            }

            if (containsMatric) {
                return server.GetStudent(matric).name;
            } else {
                return "";
            }
        }


    }
}

