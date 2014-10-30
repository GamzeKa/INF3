using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace INF3.Backend.entities
{
    public abstract class Entity
    {

        private int id;
        private bool busy = false;
        private Position pos;
        private String type = "";
        private String description = "";
        // private int ichBinderCommitTestVonChris;
        
        public Entity(int id, String type,INF3.Backend.Position pos)
        {
            setID(id);
            setType(type);
            this.pos = pos;
        }

        protected void setID(int id)
        {
            Contract.Requires(id>=0);
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

        private void setType(String t)
        {
            Contract.Requires(t != null);
            this.type = t;
        }

        public String getType()
        {
            return this.type;
        }

        public String getDescription()
        {
            return this.description;
        }

        protected void setDescription(String s)
        {
            this.description = s;
        }


        public Position getPos()
        {
            return this.pos;
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(id != null);
        }
    }
}
