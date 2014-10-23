using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestVersuch{
    [TestClass]
    public class TestBuffer{
        INF3.Buffer b = new INF3.Buffer();

        [TestMethod]
        public void BufferIsBifferEmpty()
        {
            Assert.IsTrue(b.isBufferEmpty());
        }
        [TestMethod]
        public void BufferSendToBufer()
        {
            b.sendMessage("Blablabla");

            Assert.AreEqual("Blablabla", b.getMessage());
        }
        [TestMethod]
        public void BufferIsBifferFull()
        {
            Assert.IsFalse(b.isBufferEmpty());
        }
        //----------------------------------------------
       
        [TestMethod]
        public void BufferGiveBuffer()
        {
            Assert.AreEqual("",b.giveParser());
        }
        [TestMethod]
        public void BufferMessageComplete()
        {
            Assert.IsTrue(b.MessageComplete());
        }

    }
}
