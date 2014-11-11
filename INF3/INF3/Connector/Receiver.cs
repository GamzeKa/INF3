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
        private const int sizeBuffer=15;


        public Receiver(TcpClient client)
        {
            this.client=client;
            buffer = new Buffer(sizeBuffer);
        }

        public Buffer getBufferRef()
        {
            return this.buffer;
        }
        public void receive()      //to receive data via network
        {
            try{
                while(client.Connected)
                {
                    data = new byte[client.Available];
                    client.GetStream().Read(data,0, data.Length);
                    rcvString = Encoding.ASCII.GetString(data, 0, data.Length);
                    if (rcvString.Length > 0) 
                    { 
                        this.sendToBuffer(rcvString);
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void sendToBuffer(string msg)
        {
            Contract.Requires(msg != null);

            //Console.WriteLine(msg);
            buffer.append(msg);
        }
    }
}
