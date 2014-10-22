using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF3.Backend
{
    public class Entity
    {
        private int id;
        private bool busy = false;

        public int getEntity(){
            return id;
        }
        public void setEntity(int eid)
        {
            this.id = eid;
        }
    }
}
