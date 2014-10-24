using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
        private Buffer buffer;
        private bool connected = false;
       


        public Connector(String ip, int port)
        {
            //Konstruktor, the server needs an ip-adress and a port for the unique identification
            Contract.Requires(ip != null);
            Contract.Requires(port != 0);
        }
        public void connectionClosing()
        {
            //closing the Stream from client and break off the server-connection
        }

        public void sendMessageToServer(String s)
        {
            //here send a message to the Server with the Sender-class (sender.sendMessage(String))
            Contract.Requires(s!=null);
        }

        public Buffer getBuffer()
        {
            //
            return buffer;
        }

        public void setBuffer(String b)
        {
            Contract.Requires(b != null);
            buffer.append(b);

        }

        public bool isConnected()
        {
            return connected;
        }
        public void connectToServer()
        {
           
        }

        public void sendToBuffer(object p1, string p2)
        {
          
        }


        public object getServerAnswer()
        {
            return null;
        }
    }

}
