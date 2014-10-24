using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace INF3.Backend
{
    public class Entity
    {

        private List<Entity> list = new List<Entity>();
        private int id;
        private bool busy = false;

        public int getEntity(){
            return id;
        }
        public void setEntity(int id)
        {
            Contract.Requires(eid >= 0);
            Contract.Ensures(this.id == eid);
        }
        public void setID(int id)
        {

        }
        public int getID()
        {
            return id;
        }
        public void setBusy(bool busy)
        {

        }
        public bool getBusy()
        {
            return busy;
        }
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(id != null);
            Contract.Invariant(pos != null);
        }
    }
}
