using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace INF3.Backend
{
    public class Position
    {
        private int x;
        private int y;

        public int getX() {
            return x;
        }

        public int getY() {
            return y;
        }
        public void setX(int x) {
            Contract.Requires(x >= 0);
            this.x = x;
            Contract.Ensures(this.x == x);
        }

        public void setY(int y) {
            Contract.Requires(y >= 0);
            this.y = y;
            Contract.Ensures(this.y == y);
        }
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(x >= 0);
            Contract.Invariant(y >= 0);
        }
    }
}
