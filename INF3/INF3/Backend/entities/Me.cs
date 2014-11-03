using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INF3.enums;

namespace INF3.Backend.entities
{
    public class Me : Player    //Instance of Player me
    {
        private int myId;


        public Me(int id, EnumType type, Boolean busy, String desc, int positionX, int positionY, int points)
            : base(id, type, busy, desc, positionX, positionY, points)
        {
            setMyId(id);
        }

        public int getMyId()
        {
            return this.myId;
        }

        public void setMyId(int id)
        {
            this.myId = id;
        }

        public override string ToString()
        {
            return "My Id:" + getMyId() + " Points:" + getPoints() + " Pos:" + getPos().ToString();
        }
    }
}
