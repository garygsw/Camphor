using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Camphor.Model;
using Camphor.View;

namespace Camphor.Controller {
    class AdminManager : StudentParticularsManager {

        public AdminManager (Server server) {
            this.server = server;
        }

        protected AdminManager () { }

        public string GetAdminPassword () {
            // FUNCTION: get admin password
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            return server.adminPassword;
        }

        public void SetAdminPassword (string password) {
            // FUNCTION: set admin password
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            server.adminPassword = password;
        }

        public void GetStudentList (ListView studentList) {
            // FUNCTION: fill the list with all the details
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            server.GetStudentList(studentList, true);
        }
    }
}
