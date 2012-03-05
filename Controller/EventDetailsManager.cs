using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Camphor.View;
using Camphor.Model;

namespace Camphor.Controller {
    class EventDetailsManager : EventBasicManpowerManager{

        public EventDetailsManager(Server server) {
            this.server = server;
        }

        protected EventDetailsManager () { }

        public string GetEventName(int eventID) {
            // FUNCTION: Get the name of the selected event
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            return server.GetEvent(eventID).name;
        }
        public string GetEventStartDate(int eventID) {
            // FUNCTION: Get the start date of the selected event
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            return server.GetEvent(eventID).startDate.ToString("d");
        }

        public string GetEventEndDate(int eventID) {
            // FUNCTION: Get the end date of the selected event
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            return server.GetEvent(eventID).endDate.ToString("d");
        }

        public string GetEventDescription(int eventID) {
            // FUNCTION: Get the description of the selected event
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            return server.GetEvent(eventID).description;
        }

        public string GetEventCampFees(int eventID) {
            // FUNCTION: Get the campFees
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            return server.GetEvent(eventID).campFees.ToString();
        }

    }
}
