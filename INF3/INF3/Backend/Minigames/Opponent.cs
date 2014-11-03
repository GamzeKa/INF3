using INF3.Backend.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INF3.enums;

namespace INF3.Backend.Minigames
{
    public class Opponent : Player
    {
        private int id;
        private Enum descision;
        private int points;
        private int total;

        public Opponent(int id, String des, int points, int totalString, int positionX, int positionY, Int32 total, EnumType type, bool busy)
            : base(id, type, busy, des, positionX, positionY, points)
        {
            this.id = id;
            //this.descision=des;
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
            return this.descision;
        }
    }
}
