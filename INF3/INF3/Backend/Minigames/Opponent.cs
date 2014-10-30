using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF3.Backend.Minigames
{
    public class Opponent
    {
        private int id;
        private Enum desc;
        private int points;
        private int total;

        public Opponent(int id, String desc, int points, int total)
        {
            this.id = id;

            // decission of decission

            this.points = points;
            this.total = total;
        }

        public int getID()
        {
            return id;
        }

        public int getPoints()
        {
            return points;
        }

        public int getTotal()
        {
            return total;
        }

        public Enum getDecision()
        {
            return desc;
        }


    }
    }
}
