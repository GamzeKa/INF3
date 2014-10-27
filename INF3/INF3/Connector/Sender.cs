using System;
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
        byte[] array;
        byte[] array2;


        public Sender(TcpClient client)
        {
            //Konstruktor
            this.client = client;
        }

        public void sendMessage(String message)          //send a message to the Server 
        {

            Contract.Requires(message != null);

            // Translate the passed message into UTF8 and store it as a Byte array.
            this.array = System.Text.Encoding.UTF8.GetBytes(message + "\r\n");


            Contract.Requires(client.GetStream().CanWrite == true);
            // Send the message to the connected TcpServer
             client.GetStream().Write(array, 0, array.Length);


            Contract.Requires(client.GetStream().CanWrite == false);
            Console.WriteLine("You cannot write to the Stream!");
                }
        }
    }

