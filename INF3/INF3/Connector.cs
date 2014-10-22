using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            //Konstruktor
        }
        public void connectionClosing()
        {

        }

        public void sendMessageToServer(String s)
        {

        }

        public Buffer getBuffer()
        {
            return buffer;
        }
    }

}
