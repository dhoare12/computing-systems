using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputingSystems.CombLogic.ReferenceImplementations.Tests
{
    [TestClass]
    public class DemultiplexorTests
    {
        private IDemultiplexor _demultiplexor;

        [TestMethod]
        public void DemultiplexorGateShouldBehaveCorrectly()
        {
            TestSetup.Setup();
            _demultiplexor = TypeProvider.Get<IDemultiplexor>();

            VerifyOutput(false, false, false, false);
            VerifyOutput(false, true, false, false);
            VerifyOutput(true, false, true, false);
            VerifyOutput(true, true, false, true);
        }

        private void VerifyOutput(bool input1, bool input2, bool expectedOutput1, bool expectedOutput2)
        {
            _demultiplexor.Fill(input1, input2);
            Assert.AreEqual(_demultiplexor.Output1, expectedOutput1);
            Assert.AreEqual(_demultiplexor.Output2, expectedOutput2);
        }
    }
}
