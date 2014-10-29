using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace INF3.Backend.entities
{
    public class Dragon:Entity
    {
        public Dragon(int id, String type, Boolean busy, String desc, int positionX, int positionY)
            : base(id, type, positionX, positionY)
        {
            setBusy(busy);
            setDescription(desc);
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(id != null);
            Contract.Invariant(pos != null);
        }
    }
}
