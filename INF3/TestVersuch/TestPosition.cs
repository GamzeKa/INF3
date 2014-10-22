using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVersuch
{
    class TestPosition
    {
        INF3.Backend.Position pos = new INF3.Backend.Position();


        [TestMethod]
        public void PositionGetXTest()
        {
            pos.setX(5);
            Assert.AreEqual(5,pos.getX());
        }

        [TestMethod]
        public void PositionGetYTest()
        {
            pos.setY(3);
            Assert.AreEqual(3, pos.getY());
        }

    }
}
