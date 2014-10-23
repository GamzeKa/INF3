using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestVersuch
{
    [TestClass]
    public class TestBackend
    {
        INF3.Backend.Backend b = new INF3.Backend.Backend();
        [TestMethod]
        public void BackendSendToConnector()
        {
            b.sendToConnector();
        }
        [TestMethod]
        public void BackendCreatePlayer()
        {
            INF3.Backend.Player p = new INF3.Backend.Player();
            b.storePlayer(p);
            Assert.AreEqual(1, b.getPlayers());
        }
        [TestMethod]
        public void BackendDeletePlayer()
        {
            INF3.Backend.Player p = new INF3.Backend.Player();
            b.storePlayer(p);
            b.deletePlayer(p);
            Assert.AreEqual(0, b.getPlayers());
        }
    }
}
