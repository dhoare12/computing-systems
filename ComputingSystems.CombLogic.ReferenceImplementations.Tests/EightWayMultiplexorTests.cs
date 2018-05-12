using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputingSystems.CombLogic.ReferenceImplementations.Tests
{
    [TestClass]
    public class EightWayMultiplexorTests
    {
        private IEightWayMultiplexor _multiplexor;
        private const string TestInput = "01010101";

        [TestMethod]
        public void EightWayMultiplexorGateShouldBehaveCorrectly()
        {
            TestSetup.Setup();
            _multiplexor = TypeProvider.Get<IEightWayMultiplexor>();

            VerifyOutput("000", false);
            VerifyOutput("001", true);
            VerifyOutput("010", false);
            VerifyOutput("011", true);
            VerifyOutput("100", false);
            VerifyOutput("101", true);
            VerifyOutput("110", false);
            VerifyOutput("111", true);
        }

        private void VerifyOutput(string selector, bool expectedOutput)
        {
            _multiplexor.Input = TestInput.ToBinary();
            _multiplexor.Selector = selector.ToBinary();
            Assert.AreEqual(_multiplexor.Output, expectedOutput);
        }
    }
}