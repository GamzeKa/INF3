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
        List<Player> players = new List<Player>();
        List<Dragon> dragons = new List<Dragon>();
        Map map;
        Connector c = new Connector();

        //Player
        public void storePlayer(Player p)
        {
            Contract.Requires(p.GetType() == typeof(Player));
            players.Add(p);
            Contract.Ensures(players.Count > 0);
        }
        public void deletePlayer(Player p)
        {
            Contract.Requires(p.GetType() == typeof(Player));
            players.Remove(p);
        }
        //Dragons
        public void storeDragon(Dragon d)
        {
            Contract.Requires(d.GetType()==typeof(Dragon));
            dragons.Add(d);
            Contract.Ensures(dragons.Count > 0);
        }
        public void deleteDragon(Dragon d)
        {
            Contract.Requires(d.GetType() == typeof(Dragon));
            dragons.Remove(d);
        }

        public void sendToConnector(String value)
        {
            Contract.Requires(value != null);
            c.sendMessageToServer("");
        }
        public Connector getConnector()
        {
            Contract.Ensures(this.c.GetType() == typeof(Connector));
            return c;
        }
        public Map getMap()
        {
            Contract.Ensures(this.m.GetType() == typeof(Map));
            return map;
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(map != null);
            Contract.Invariant(c != null);
        }
    }
}
