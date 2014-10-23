using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestVersuch
{
    [TestClass]
    public class TestParser
    {
        INF3.Parser p = new INF3.Parser();
        INF3.Buffer b = new INF3.Buffer();

        [TestMethod]
        public void testTakeFromBuffer()
        {
            b.sendMessage("Blablabla");

            Assert.AreEqual("Blablabla", p.takeFromBuffer());
        }
    }
}
