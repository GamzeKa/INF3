using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace INF3.Connector
{
    class Receiver
    {
        private TcpClient client;
        byte [] data;


        public Receiver(TcpClient client)
        {
            this.client=client;
        }
        public String receive()      //to receive data via network
        {

            String s=String.Empty;
            try{
                data=new byte[client.Available];
                // size of the array for the answer was defined

                // client read the answer from the server and save this in a array
                // define a type -->var because the type of the answer is unknown
                // asychron var for unblocking processes
                var reader = client.GetStream().BeginRead(data, 0, data.Length,null,null);

                // BeginRead -> start the asynchronReader
                // EndRead -> end of the asynchronRead. Save the bytes of read in int
                int reads = client.GetStream().EndRead(reader);


                // the bytecode convert to String
                if (client.Connected)
                {
                    return System.Text.Encoding.UTF8.GetString(data, 0, reads);
                }
                else
                {
                    return null;
                }
                
            }catch(Exception d){
                Console.WriteLine(d);
                return null;
                }
            
        }
    }
}
