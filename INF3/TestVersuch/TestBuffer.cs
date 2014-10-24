using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestVersuch{
    [TestClass]
    public class TestBuffer{
        INF3.Buffer b = new INF3.Buffer();
        INF3.Connector c = new INF3.Connector();

        [TestMethod]
        public void BufferIsBufferEmpty()
        {
            Assert.IsTrue(b.isBufferEmpty());
        }

        public void BufferMessageappend() { 
            b.append("ashdjk");
            Assert.AreEqual("",b.getMessage());

        }
        
        [TestMethod]
        public void BufferDeleteMessage()
        {
            b.append("message");
            b.clearBuffer();
            Assert.IsTrue(b.isBufferEmpty());
        }
        //----------------------------------------------
       
        [TestMethod]
        public void BufferGiveParser()
        {   
            Assert.AreEqual("",b.giveParser());
        }
        [TestMethod]
        public void BufferMessageComplete()
        {
            c.getBuffer();
            Assert.IsTrue(b.MessageComplete());
        }

    }
}
