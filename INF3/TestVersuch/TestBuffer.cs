using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestVersuch{
    [TestClass]
    public class TestBuffer{
        INF3.Buffer b = new INF3.Buffer();
        [TestMethod]
        public void testIsBufferEmpty(){
            Assert.IsTrue(b.isBufferEmpty());
        }

        [TestMethod]
        public void testGiveBuffer()
        {
            Assert.AreEqual("",b.giveParser());
        }

        [TestMethod]
        public void testMessageComplete()
        {
            Assert.IsTrue(b.MessageComplete());
        }

    }
}
