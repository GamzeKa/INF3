using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestVersuch
{
    [TestClass]
    public class TestBackend
    {
        INF3.Backend.Backend backend = new INF3.Backend.Backend();
        [TestMethod]
        public void BackendSendToConnector()
        {
            backend.sendToConnector("Hat jemand meine Freunde gesehen? Sie sollten so ähnlich aussehen wie ich...");
            Assert.AreEqual("", backend.getConnector().getParser().takeFromBuffer());
        }
        [TestMethod]
        public void BackendCreatePlayer()
        {
            INF3.Backend.Player p = new INF3.Backend.Player();
            backend.storePlayer(p);
            Assert.AreEqual(1, backend.getPlayers());
        }
        [TestMethod]
        public void BackendDeletePlayer()
        {
            INF3.Backend.Player p = new INF3.Backend.Player();
            backend.storePlayer(p);
            backend.deletePlayer(p);
            Assert.AreEqual(0, backend.getPlayers());
        }
        [TestMethod]
        public void BackendCreateDragon()
        {
            INF3.Backend.Dragon d = new INF3.Backend.Dragon();
            b.storeDragon(d);
            Assert.AreEqual(1, backend.getDragons());
        }
        [TestMethod]
        public void BackendDeleteDragon()
        {
            INF3.Backend.Dragon d = new INF3.Backend.Dragon();
            backend.storeDragon(d);
            backend.deleteDragon(d);
            Assert.AreEqual(0, backend.getDragons());
        }
        [TestMethod]
        public void BackendMap()
        {
            Assert.IsNotNull(backend.getMap());
        }
    }
}
