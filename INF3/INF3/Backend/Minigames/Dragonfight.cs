using INF3.Backend.Minigames;
using INF3.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INF3.Backend
{
    public class Dragonfight :Game
    {
        private EnumDragonfight enumDragon;

        public Dragonfight(int id, bool accepted)
            : base(id, accepted)
        {
            enumDragon = new EnumDragonfight();

        }

        public EnumDragonfight getEnum()
        {
            return enumDragon;
        }

        public void setEnum(String desc)
        {
          
        }
    }
}
