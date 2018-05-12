using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputingSystems.CombLogic.ReferenceImplementations.Tests
{
    [TestClass]
    public class MultiplexorTests
    {
        private IMultiplexor _multiplexor;

        [TestMethod]
        public void MultiplexorGateShouldBehaveCorrectly()
        {
            TestSetup.Setup();
            _multiplexor = TypeProvider.Get<IMultiplexor>();

            VerifyOutput(false, false, false, false);
            VerifyOutput(false, false, true, false);
            VerifyOutput(false, true, false, false);
            VerifyOutput(false, true, true, true);
            VerifyOutput(true, false, false, true);
            VerifyOutput(true, false, true, false);
            VerifyOutput(true, true, false, true);
            VerifyOutput(true, true, true, true);
        }

        private void VerifyOutput(bool input1, bool input2, bool input3, bool expectedOutput)
        {
            _multiplexor.Fill(input1, input2, input3);
            Assert.AreEqual(_multiplexor.Output, expectedOutput);
        }
    }
}
