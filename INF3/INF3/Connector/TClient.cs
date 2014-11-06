using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace INF3.Connector
{
    class TClient
    {
        private TcpClient client;
        String ip;
        Int32 port;
        

        public TClient(String ip, Int32 port)   //Konstruktor transfer the ip and port to the Client
        {
            //Check if data is correct
            this.ip = ip;
            this.port = port;
            try
            {
                this.client = new TcpClient();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void Close()     //Closes the Connection
        {
            try
            {
                if (client.Connected)
                {
                    client.Close();
                }
                    Contract.Ensures(!client.Connected);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        protected void setTClient(TcpClient client)
        {
            try
            {
                this.client = client;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public TcpClient getTClient()
        {
            try
            {
                if (client.Connected)
                {
                    return client;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        public void TConnect()     // if the client is not connected then the method connect 
                                                        //with ip-adress and port
        {
            try
            {
                Contract.Requires(!client.Connected);
                if (!client.Connected)
                {
                    client.Connect(this.ip, this.port);
                }
                Contract.Ensures(client.Connected);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
               
        }
         public NetworkStream getStream()
        {
             // the Method transfers the Stream to the Network
            return client.GetStream();
        }
    }


    }

