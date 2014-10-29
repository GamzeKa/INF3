using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace INF3.Backend
{
    public class Backend
    {
        
        Buffer b;
        Parser p;
        Map.Map map;
        Connector c = new Connector("192.168.178.1",8080);

        public Backend;

        //Parser
        public void showMessage() //show Message on GUI
        {
            
        }

        

        //Map
        public void setMap(Map.Map map)
        {

        }
        public Map.Map getMap()
        {
            Contract.Ensures(this.map.GetType() == typeof(Map));
            return map;
        }

        public void updateCell()
        {

        }

        //Connector
        public void sendToConnector(String value)
        {
            Contract.Requires(value != null);
            c.sendMessageToServer(value);
        }

        public Connector getConnector()
        {
            Contract.Ensures(this.c.GetType() == typeof(Connector));
            return c;
        }

        public void receiveTime()
        {

        }

        public void onlineInfo()
        {

        }

        public void yourID()
        {

        }

        public void challangeInfo()
        {

        }

        public void opponentInfo()
        {

        }

        public void serverAnswer()
        {

        }

        public void gameInfo()
        {

        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(map != null);
            Contract.Invariant(c != null);
        }
    }
}
