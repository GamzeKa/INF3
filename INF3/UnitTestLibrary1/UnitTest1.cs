using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using INF3;


namespace UnitTestLibrary1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1(){
            Boolean x = false;
            Assert.IsFalse(x);
            
        }
    }
}
