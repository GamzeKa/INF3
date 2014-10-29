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
        INF3.Connector.Connector c = new INF3.Connector.Connector("192.168.178.1",8080);

        private INF3.Backend.entities.EntityManager em= new INF3.Backend.entities.EntityManager();
        

        private static Dragonfight dragonhunt; //Games
        private static Skirmish skirmish;
        private static Staghunt staghunt;

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

        public INF3.Connector.ConnectorConnector getConnector()
        {
            Contract.Ensures(this.c.GetType() == typeof(INF3.Connector.ConnectorConnector));
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

        public void storePlayer(INF3.Backend.entities.Player p)
        {
            em.storePlayer(p);
        }

        public void deletePlayer(INF3.Backend.entities.Player p)
        {
            em.deletePlayer(p);
        }

        public int getPlayerAmount()
        {
            return em.getPlayerAmount();
        }

        public void updatePlayer(INF3.Backend.entities.Player player, Position pos)
        {
            em.updatePlayer(player, pos);
        }

        //Dragons
        public void storeDragon(INF3.Backend.entities.Dragon d)
        {
            em.storeDragon(d);
        }

        public void deleteDragon(INF3.Backend.entities.Dragon d)
        {
            em.deleteDragon(d);
        }

        public int getDragonAmount()
        {
            return em.getDragonAmount();
        }

        public void updateDragon(INF3.Backend.entities.Dragon d, Position pos)
        {
            em.updateDragon(d,pos);
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(map != null);
            Contract.Invariant(c != null);
        }
    }
}
