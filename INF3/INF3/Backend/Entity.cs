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
        private int id;
        private bool busy = false;

        public int getID(){
            return id;
        }
        public void setID(int id)
        {
            Contract.Requires(id >= 0);
            Contract.Ensures(this.id == id);
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
        }
    }
}
