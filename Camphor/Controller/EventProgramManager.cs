using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Camphor.Model;
using Camphor.View;

namespace Camphor.Controller {
    class EventProgramManager : EventDetailsManager {

        public EventProgramManager (Server server) {
            this.server = server;
        }

        protected EventProgramManager () { }
    }
}
