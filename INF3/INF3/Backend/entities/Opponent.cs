using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INF3.Backend
{
    class Opponent : entities.Player

    {
        private Int32 total;

        public Opponent(Int32 total,  int id, String type, Boolean busy, String des, int positionX, int positionY, int points)
            : base(id, type, busy, des, positionX, positionY, points)
        {
            this.total = total;
            
        }
        

        public Int32 getTotal()
        {
            return total;
        }

        
    }
}
