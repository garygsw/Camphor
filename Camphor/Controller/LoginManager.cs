using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Camphor.Model;
using Camphor.View;

namespace Camphor.Controller {
    class LoginManager : AdminManager {

        string masterPassword = "SBTK";

        public LoginManager (Server server) {
            // FUNCTION: intialise the class
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 

            this.server = server;
        }

        public bool CheckAdmin (string password) {
            // FUNCTION: check for the password of the admin
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 

            if (password == GetAdminPassword() || password == masterPassword ) return true;
            else return false;
        }

        public bool CheckPassword (string matric, string password) {
            // FUNCTION: check for the password of the student
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 

            try {
                if (GetPassword(matric) == password) return true;
                else return false;
            } catch (KeyNotFoundException) {
                return false;
            }
        }

    }
}
