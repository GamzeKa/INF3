using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace INF3.Connector
{
    public class Receiver
    {
        private TcpClient client;
        byte [] data;
        private String rcvString;
        private Buffer buffer;


        public Receiver(TcpClient client)
        {
            this.client=client;
            buffer = new Buffer(15);
        }
        public void receive()      //to receive data via network
        {
            try{
                while(true)
                {
                    data = new byte[1024];
                    int recv = client.Client.Receive(data);
                    rcvString = Encoding.ASCII.GetString(data, 0, recv);
                    this.sendToBuffer(rcvString);
                }
            }catch(Exception d)
            {
                Console.WriteLine(d);
            }
        }
        public void sendToBuffer(string msg)
        {
            Contract.Requires(msg != null);

            Console.WriteLine(msg);
            //buffer.append(msg);
        }
    }
}
