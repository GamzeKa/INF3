using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF3.Connector
{
    public abstract class ConnectionManager
    {

        private static Connector connector;

        public static void ManageConnect(String ip, Int32 port) {

            connector = new Connector(ip, port);
        }

        public static Connector getConnector()
        {
            return connector;
        }

        public static void CloseConnector()
        {
            connector.closeConnection();
        }
    }
}
