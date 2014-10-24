using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace INF3
{
    class Sender        // the class to send data via network to the server
    {
        public Sender()
        {
            //Konstruktor
        }
        public void sendMessage(String message)
        {
            Contract.Requires(message != null);
            //here to send a message to the Server 
        }
    }
}
