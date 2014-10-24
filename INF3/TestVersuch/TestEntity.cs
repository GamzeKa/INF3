using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestVersuch{
    [TestClass]
    public class TestEntity{
        INF3.Backend.Entity e = new INF3.Backend.Entity();

        [TestMethod]
        public void EntityGetEntity()
        {
            e.setEntity(5);
            Assert.AreSame(5,e.getEntity());
        }
        [TestMethod]
        public void EntityGetID()
        {
            Assert.AreSame(1, e.getID());
        }
        [TestMethod]
        public void EntityGetBusy()
        {
            Assert.AreSame(1, e.getBusy());
        }
    }
}
