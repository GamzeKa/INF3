using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestVersuch{
    [TestClass]
    public class TestBuffer{
        INF3.Buffer b = new INF3.Buffer();

        [TestMethod]
        public void BufferIsBufferEmpty()
        {
            Assert.IsTrue(b.isBufferEmpty());
        }
        [TestMethod]
        public void BufferSendToBufer()
        {
            b.sendMessage("Ich bin auch ein Platzhalter, wie mein Kollege der sich auch hier irgendwo versteckt");

            Assert.AreEqual("Blablabla", b.getMessage());
        }
        [TestMethod]
        public void BufferDeleteMessage()
        {
            b.deleteMsg("Ich bin auch ein Platzhalter, wie mein Kollege der sich auch hier irgendwo versteckt");
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
