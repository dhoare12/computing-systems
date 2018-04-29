using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputingSystems.CombLogic.Tests
{
    [TestClass]
    public class GateTests
    {
        [TestMethod]
        public void NandTest()
        {
            new SingleOutputTester().Test(new Nand());
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void NotTest()
        {
            new SingleOutputTester().Test(new Not());
            Assert.AreEqual(true, true);
        }
    }

    
}
