using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Camphor.Model;
using Camphor.View;

namespace Camphor.Controller {
    class EventBasicManpowerManager {
        protected Server server;

        public EventBasicManpowerManager (Server server) {
            this.server = server;
        }

        protected EventBasicManpowerManager () { }

        public void StudentJoinEvent (string matric, int id, int role) {
            // FUNCTION: add student into the program role 1 = organizer, 2 = facilitator, 3 = participant
            // PRE-CONDITIONS: assuming id exist
            // POST-CONDITIONS:
            server.GetStudent(matric).AddEvents(server, id, role);
        }
    }
}
