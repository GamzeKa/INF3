using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestVersuch{
    [TestClass]
    public class TestBuffer{
        INF3.Buffer b = new INF3.Buffer();
        [TestMethod]
        public void TestIsBufferEmpty(){
            Assert.IsTrue(b.isBufferEmpty());
        }

        [TestMethod]
        public void TestGiveBuffer()
        {
            Assert.AreEqual("",b.giveParser());
        }

        [TestMethod]
        public void TestMessageComplete()
        {
            Assert.IsTrue(b.MessageComplete());
        }
    }
}
