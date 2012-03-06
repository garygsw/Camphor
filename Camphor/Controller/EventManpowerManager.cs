using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using Camphor.Model;
using Camphor.View;

namespace Camphor.Controller {
    class EventManpowerManager : EventBasicManpowerManager {
        
        public EventManpowerManager (Server server) {
            this.server = server;
        }

        // public void that sends in a refernce listview of the manpower
        public void GetOrganiserList(ListView organiserListView, int eventID) {
            Event campEvent = server.GetEvent(eventID);
            campEvent.GetOrganiserList(organiserListView, this.server);
        }

        public void GetFacilitatorList(ListView facilitatorListView, int eventID) {
            Event campEvent = server.GetEvent(eventID);
            campEvent.GetFacilitatorList(facilitatorListView, this.server);
        }

        public void GetParticipantList(ListView participantListView, int eventID) {
            Event campEvent = server.GetEvent(eventID);
            campEvent.GetParticipantList(participantListView, this.server);
        }

        public void RemoveStudent(string matric, int eventID, int role) {
            server.GetStudent(matric).DeleteEvents(this.server, eventID);
            Event campEvent = server.GetEvent(eventID);
            if (role == 1) campEvent.DeleteOrganiser(matric, server);
            else if (role == 2) campEvent.DeleteFacilitator(matric);
            else if (role == 3) campEvent.DeleteParticipant(matric);
        }

        public void EditStudentPaidStatus(string matric, int eventID, int role, bool paid) {
            Event campEvent = server.GetEvent(eventID);
            
            if (paid) {
                switch (role) {
                    case 1:
                        campEvent.EditOrganiser(matric, true);
                        break;
                    case 2:
                        campEvent.EditFacilitator(matric, true);
                        break;
                    case 3:
                        campEvent.EditParticipant(matric, true);
                        break;
                }
            } else {
                switch (role) {
                    case 1:
                        campEvent.EditOrganiser(matric, false);
                        break;
                    case 2:
                        campEvent.EditFacilitator(matric, false);
                        break;
                    case 3:
                        campEvent.EditParticipant(matric, false);
                        break;
                }
            }
        }
    }
}
