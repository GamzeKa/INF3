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
        public void setEntity(int eid)
        {
            Contract.Requires(eid >= 0);
            this.id = eid;
            Contract.Ensures(this.id == eid);
        }
        public void setID(int id)
        {
            Contract.Requires(id>=0));
            this.id = id;
            Contract.Ensures(this.id == id);
        }
        public int getID()
        {
            return id;
        }
        public void setBusy(bool busy)
        {
            Contract.Requires(busy.GetType() == typeof(bool));
            this.busy = busy;
            Contract.Ensures(this.busy == busy);
        }
        public bool getBusy()
        {
            Contract.Ensures(busy.GetType() == typeof(bool));
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
