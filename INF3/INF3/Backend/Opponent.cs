using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INF3.Backend
{
    class Opponent
    {
        private Int32 id;
        private String desc;
        private Int32 points;
        private Int32 total;

        public Int32 getID()
        {
            return id;
        }

        public Int32 getPoints()
        {
            return points;
        }

        public Int32 getTotal()
        {
            return total;
        }

        public String getDecision()
        {
            return desc;
        }
    }
}
