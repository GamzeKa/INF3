using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF3.Backend
{
    public class Backend
    {
        List<Player> player = new List<Player>();
        Map map;

        public void storePlayer(Player p)
        {
            player.Add(p);
        }
        public void deletePlayer(Player p)
        {
            player.Remove(p);
        }

        public void sendToConnector()
        {
            INF3.Connector.sendMessageToServer();
        }
    }
}
