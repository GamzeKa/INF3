using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;

namespace INF3
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/
            INF3.Connector.Connector c = new Connector.Connector("127.0.0.1",666);

            Buffer b =c.getBuffer();
            while (true)
            {
                if (!b.isBufferEmpty())
                {
                    Console.WriteLine(b.getMessage());
                }
            }
        }
    }
}

