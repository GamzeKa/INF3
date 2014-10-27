using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF3.Backend.entities
{
    class EntityManager
    {
        List<Player> players = new List<Player>();
        List<Dragon> dragons = new List<Dragon>();

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

        public int getPlayerAmount()
        {
            return players.Count;
        }

        public void updatePlayer(Player player, Position pos)
        {
            if (p == null)
            {
                throw new ArgumentNullException("Kein Spieler zum updaten vorhanden.");
            }
            else
            {
                foreach (Player pl in this.players)
                {
                    if (pl.Equals(player))
                    {
                        //update this player
                    }
                }
            }


        }

        //Dragons
        public void storeDragon(Dragon d)
        {
            Contract.Requires(d.GetType() == typeof(Dragon));
            dragons.Add(d);
            Contract.Ensures(dragons.Count > 0);
        }

        public void deleteDragon(Dragon d)
        {
            Contract.Requires(d.GetType() == typeof(Dragon));
            dragons.Remove(d);
        }

        public int getDragonAmount()
        {
            return dragons.Count;
        }

        public void updateDragon(Dragon d, Position pos)
        {

        }
    }
}
