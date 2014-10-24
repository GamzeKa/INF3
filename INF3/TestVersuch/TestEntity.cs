using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestVersuch{
    [TestClass]
    public class TestEntity{
        INF3.Backend.Entity e = new INF3.Backend.Entity();

        [TestMethod]
        public void EntityGetEntity()
        {
            e.setID(5);
            Assert.AreSame(5,e.getID());
        }
        [TestMethod]
        public void EntityGetBusy()
        {
            e.setBusy(true);
            Assert.IsTrue(e.getBusy());
        }
    }
}
