using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace INF3.Connector
{
    public class Connector
    {
        private Sender sender;
        private Receiver receive;
        private static Buffer buffer;
        private static bool connected = true;
        private TClient client;



        public Connector(String ip, int port)
        {
            //Konstruktor, the server needs an ip-adress and a port for the unique identification
            Contract.Requires(ip != null);
            Contract.Requires(port != 0);
            client = new TClient(ip,port);
            receive = new Receiver(client.getTClient());
            sender = new Sender(client.getTClient());
            buffer = new Buffer();

        }
        public void closeConnection()
        {
            //closing the Stream from client and break off the server-connection
            try
            {
                // close the stream
                client.getStream().Close();
                // closes the server-connection 
                client.Close();

            }
            catch (Exception g)
            {
                Console.WriteLine(g.Message);
            }
        }


        public void sendMessageToServer(String s)
        {
            //here send a message to the Server with the Sender-class (sender.sendMessage(String))
            Contract.Requires(s!=null);

            sender.sendMessage(s);
        }

        public Buffer getBuffer()
        {
            //
            return buffer;
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
            Contract.Requires(p1 != null);
            Contract.Requires(p2 != null);
            buffer.append(p2);
        }


        public object getServerAnswer()
        {
            return null;
        }
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(sender != null);
            Contract.Invariant(receive != null);
            Contract.Invariant(buffer != null);
        }
    }

}
