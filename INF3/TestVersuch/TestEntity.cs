using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestVersuch{
    [TestClass]
    public class TestEntity{
        INF3.Backend.Entity e = new INF3.Backend.Entity();

        [TestMethod]
        public void EntityGetEntity()
        {
            Assert.AreSame(1,e.getEntity());
        }
        [TestMethod]
        public void EntityGetEntitys()
        {
            Assert.AreSame(1, e.getEntitys());
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
