using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVersuch
{
    class TestConnector
    {
        INF3.Connector c = new INF3.Connector("192.168.2.1",80);
        INF3.Backend.Backend b = new INF3.Backend.Backend();
        
        
        [TestMethod]
        public void ConnectorSendToBuffer()
        {
            c.setBuffer("Test");
            Assert.AreEqual("Test", c.getBuffer().getMessage());
        }
        [TestMethod]
        public void ConnectorSendToServer()
        {
            c.sendMessageToServer("Ich bin ein Platzhalter");
            Assert.AreEqual("OK", c.getServerAnswer());
        }
        //-----------------------------
        [TestMethod]
        public void ConnectorIsConnected()
        {
            Assert.IsTrue(c.isConnected());
        }
        [TestMethod]
        public void ConnectorHasBuffer()
        {
            Assert.IsNotNull(c.getBuffer());
        }
        [TestMethod]
        public void ConnectorIsConnected()
        {
            Assert.IsTrue(c.isConnected());
        }
    }
}
