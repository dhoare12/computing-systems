using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputingSystems.CombLogic.ReferenceImplementations.Tests
{
    [TestClass]
    public class XorTests
    {
        private IXor _xor;

        [TestMethod]
        public void XorGateShouldBehaveCorrectly()
        {
            TestSetup.Setup();
            _xor = TypeProvider.Get<IXor>();

            VerifyOutput(false, false, false);
            VerifyOutput(false, true, true);
            VerifyOutput(true, false, true);
            VerifyOutput(true, true, false);
        }

        private void VerifyOutput(bool input1, bool input2, bool expectedOutput)
        {
            _xor.Input1 = input1;
            _xor.Input2 = input2;
            Assert.AreEqual(_xor.Output, expectedOutput);
        }
    }
}