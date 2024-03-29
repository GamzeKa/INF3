﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestVersuch{
    [TestClass]
    public class TestPlayer{
        INF3.Backend.Player p = new INF3.Backend.Player();

        [TestMethod]
        public void PlayerGetStaghuntDecision(){
            p.setStaghuntDecision(true);
            Assert.IsTrue(p.getStaghuntDecision());
        }

        [TestMethod]
        public void PlayerGetDragonDecision()
        {
            p.setDragonDecision(true);
            Assert.IsTrue(p.getDragonDecision());
        }

       
        public void PlayergetSkirmishDecision()
        {
            p.setSkirmishDecision(true);
            Assert.IsTrue(p.getSkirmishDecision());
        }

        [TestMethod]
        public void PlayerTestPoints()
        {
            p.setPoints(0);
            p.addPoints(10);
            Assert.AreEqual(10, p.getPoints());
        }

    }
}
