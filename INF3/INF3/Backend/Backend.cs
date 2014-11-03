using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INF3.Connector;
using INF3.Backend.entities;
using System.Diagnostics.Contracts;

namespace INF3.Backend
{
    public class Backend
    {

        private Buffer b;
        private Parser p;
        private Map.Map map;
        private Connector.Connector c;
        private EntityManager em;
        

        private static Dragonfight dragonhunt; //Games
        private static Skirmish skirmish;
        private static Staghunt staghunt;

        public Backend()
        {
            c = new INF3.Connector.Connector("192.168.178.1", 8080);
            em = new INF3.Backend.entities.EntityManager();
            b= new Buffer(15);
        }


        //Parser
        public void setMessage(String message)
        {
            Contract.Requires(message != null);
        }

        //Map
        public void setMap(Map.Map map)
        {

        }
        public Map.Map getMap()
        {
            Contract.Ensures(this.map.GetType() == typeof(Map.Map));
            return map;
        }

        public void updateCell(Int32 row, Int32 col, List<enums.Property> property)
        {

        }

        //Connector
        public void sendToConnector(String value)
        {
            Contract.Requires(value != null);
            c.sendMessageToServer(value);
        }

        public Connector.Connector getConnector()
        {
            Contract.Ensures(this.c.GetType() == typeof(Connector.Connector));
            return c;
        }

        public void receiveTime(long time)
        {

        }

        public void onlineInfo(Int32 online)
        {

        }

        public void yourID(Int32 yourid)
        {

        }

        public void setChallange(INF3.Backend.Minigames.Game minigame)
        {

        }

        public void setOpponent(Opponent o)
        {

        }

        public void serverAnswer(String answer)
        {

        }

        public void setResult(Int32 round, Boolean running,Int32 delay)
        {

        }

        public void storePlayer(INF3.Backend.entities.Player p)
        {
            em.storePlayer(p);
        }

        public void deletePlayer(Int32 idDragon, String typ)
        {
            //em.deletePlayer();
        }

        public int getPlayerAmount()
        {
            return em.getPlayerAmount();
        }

        public void updatePlayer(Int32 id, String typ, Boolean busyboolean, String description, Int32 x, Int32 y,Int32 points)
        {
            //em.updatePlayer(player, pos);
        }

        //Dragons
        public void storeDragon(INF3.Backend.entities.Dragon d)
        {
            em.storeDragon(d);
        }

        public void deleteDragon(Int32 idDragon, String typ)
        {
            //em.deleteDragon();
        }

        public int getDragonAmount()
        {
            return em.getDragonAmount();
        }

        public void updateDragon(Int32 id,String typ,Boolean busyboolean,String description,Int32 x,Int32 y)
        {
            //em.updateDragon(d,pos);
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(map != null);
            Contract.Invariant(c != null);
        }
    }
}
