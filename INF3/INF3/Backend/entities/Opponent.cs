using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using INF3.enums;

namespace INF3.Backend
{
    public class Opponent : entities.Player

    {
        private Int32 total;

        public Opponent(Int32 total, int id, EnumType type, Boolean busy, String des, int positionX, int positionY, int points)
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
