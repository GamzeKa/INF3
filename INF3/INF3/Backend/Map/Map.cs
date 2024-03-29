﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace INF3.Backend.Map
{
    public class Map
    {
        private MapCell[,] mapArray;
        private int width;
        private int height;

        public Map(int width, int height)
        {
            this.mapArray = new MapCell[width, height];
            setWidth(width);
            setHeight(height);
        }

        private void setWidth(int w)
        {
            Contract.Requires(w >= 0);
            this.width = w;
            Contract.Ensures(this.width == w);
        }

        public int getWidth(int w)
        {
            Contract.Ensures(this.width >= 0);
                return this.width;
        }

        private void setHeight(int h)
        {
            Contract.Requires(h >= 0);
            this.height = h;
            Contract.Ensures(this.height == h);
        }

        public int getHeight()
        {
            Contract.Ensures(this.height >= 0);
                return this.height;
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
