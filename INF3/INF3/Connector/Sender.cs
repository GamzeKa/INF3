﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;
using System.Net.Sockets;

namespace INF3.Connector
{
    class Sender        // the class to send data via network to the server
    {

        TcpClient client;
        byte[] data;


        public Sender(TcpClient client)
        {
            this.client = client;
        }

        public void sendMessage(String message)          //send a message to the Server 
        {
            Contract.Requires(message != null);
            Contract.Requires(!client.GetStream().CanWrite);

            if (message != null)
            {
                // Translate the passed message and store it as a Byte array.
                this.data = System.Text.Encoding.ASCII.GetBytes(message + "\n");
                client.GetStream().Write(data, 0, data.Length);
            }
        }
    }
}