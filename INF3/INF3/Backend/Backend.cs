﻿using System;
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
        Connector c = new Connector();

        public void storePlayer(Player p)
        {
            player.Add(p);
        }
        public void deletePlayer(Player p)
        {
            player.Remove(p);
        }

        public void sendToConnector(String value)
        {
            c.sendMessageToServer("");
        }
        public Connector getConnector()
        {
            return c;
        }
    }
}
