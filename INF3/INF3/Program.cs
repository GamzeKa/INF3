using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Threading;

namespace INF3
{
    static class Program
    {
      
        [STAThread]
        public static void Main()
        {
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/
            INF3.Connector.Connector c = new Connector.Connector("127.0.0.1",666);

            c.connectToServer();
            c.send("get:time");
            c.send("get:map");

            Buffer b = c.getBufferRef();
            while (true) { 
                Console.WriteLine(b.giveParser());
                Console.WriteLine("-------------------------------------");
                for (int i=0; i < 50000000; i++);
            }
            
            //c.closeConnection();
        }
    }
}

