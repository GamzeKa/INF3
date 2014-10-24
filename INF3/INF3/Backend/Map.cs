using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace INF3.Backend
{
    public class Map
    {
        protected MapCell[,] mapArray;
        protected int width;
        protected int height;

        private void setWidth(int w)
        {
            Contract.Requires(w >= 0);
            this.width = w;
            Contract.Ensures(this.width == w);
        }
        private int getWidth(int w)
        {
            Contract.Ensures(this.width >=0)
                return this.width;;
        }
        private void setHeight(int h)
        {
            Contract.Requires(h >= 0);
            this.height = h;
            Contract.Ensures(this.height == h);
        }
        private int getWidth(int w)
        {
            Contract.Ensures(this.height >=0)
                return this.height;;
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(mapArray != null);
            Contract.Invariant(width >= 0);
            Contract.Invariant(height >= 0);
        }
    }
}
