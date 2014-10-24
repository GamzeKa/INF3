﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace INF3.Backend
{
    public class Dragon
    {
        private int id;
        private Position pos;
        public int getDragonCount() {
            return 1;
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(id != null);
            Contract.Invariant(pos != null);
        }
    }
}
