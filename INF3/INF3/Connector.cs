using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace INF3
{
    public class Connector
    {
        private Sender sender;
        private Receiver receiv;
        private bool isAktiv;
        private Buffer buffer;
       


        public Connector(String ip, int port)
        {
            //Konstruktor, connector and the server needs an ip-adress and a port for the unique identification
        }
        public void connectionClosing()
        {
            //closing the Stream from client and break off the server-connection
        }

        public void sendMessageToServer(String s)
        {
            //here send a message to the Server with the Sender-class (sender.sendMessage(String))
        }

        public Buffer getBuffer()
        {
            //
            return buffer;
        }
    }

}
