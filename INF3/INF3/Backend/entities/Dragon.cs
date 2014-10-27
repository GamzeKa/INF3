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


        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(id != null);
            Contract.Invariant(pos != null);
        }
    }
}
