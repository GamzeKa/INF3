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
        INF3.Buffer b = new INF3.Buffer();
        
        [TestMethod]
        public void ConnectorConnectToServer()
        {
            c.connectToServer();
            Assert.IsTrue(c.isConnected());
        }
        [TestMethod]
        public void ConnectorSendToBuffer()
        {
            c.sendToBufer("Test");
            Assert.AreEqual("Test", b.getMsg());
        }
        [TestMethod]
        public void ConnectorSendToServer()
        {
            c.sendToServer();
            Assert.AreEqual("OK", c.getServerAnswer());
        }
    }
}
