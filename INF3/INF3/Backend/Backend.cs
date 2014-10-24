using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            players.Add(p);
        }
        public void deletePlayer(Player p)
        {
            players.Remove(p);
        }
        //Dragons
        public void storeDragon(Dragon d)
        {
            dragons.Add(d);
        }
        public void deleteDragon(Dragon d)
        {
            dragons.Remove(d);
        }

        public void sendToConnector(String value)
        {
            c.sendMessageToServer("");
        }
        public Connector getConnector()
        {
            return c;
        }
        public Map getMap()
        {
            return map;
        }
    }
}
