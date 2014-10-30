using INF3.Backend.entities;
using INF3.Backend.Minigames;
using INF3.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF3.Backend
{
    public class Skirmish : Game
    {
        private EnumSkirmish enumSkirmish;

        public Skirmish(int id, bool accepted)
            : base(id, accepted)
        {
            enumSkirmish = new EnumSkirmish();

        }

        public EnumSkirmish getEnum()
        {
            return enumSkirmish;
        }

        public void setEnum(String desc)
        {
            
        }
    }
}
