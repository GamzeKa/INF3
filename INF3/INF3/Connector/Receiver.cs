﻿using System;
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
                while(true)//connecteds
                {
                    data = new byte[1024];
                    int recv = client.Client.Receive(data);
                    rcvString = Encoding.ASCII.GetString(data, 0, recv);
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

            Console.WriteLine(msg);
            /*lock(buffer){
                buffer.append(msg);
            }*/
        }
    }
}
