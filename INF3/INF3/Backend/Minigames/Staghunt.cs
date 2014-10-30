using INF3.Backend.Minigames;
using INF3.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INF3.Backend
{
    public class Staghunt : Game
    {
        private EnumStaghunt enumStaghunt;

        public Staghunt(int id, bool accepted)
            : base(id, accepted)
        {
            enumStaghunt = new EnumStaghunt();

        }

        public EnumStaghunt getEnum()
        {
            return enumStaghunt;
        }

        public void setEnum(String desc)
        {
            
        }
    }
}
