using INF3.Backend.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF3.Backend.Minigames
{
    public abstract class Game
    {
        private int id;
        private bool excepted;
        private Player opponent;

        public Game(int id, bool excepted, Player opponent)
        {
            this.id = id;
            this.excepted = excepted;
            this.opponent = opponent;


        }
    }
}
