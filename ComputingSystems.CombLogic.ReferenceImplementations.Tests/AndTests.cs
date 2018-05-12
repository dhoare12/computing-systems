using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputingSystems.CombLogic.ReferenceImplementations.Tests
{
    [TestClass]
    public class AndTests
    {
        private IAnd _and;

        [TestMethod]
        public void AndGateShouldBehaveCorrectly()
        {
            TestSetup.Setup();
            _and = TypeProvider.Get<IAnd>();

            VerifyOutput(false, false, false);
            VerifyOutput(false, true, false);
            VerifyOutput(true, false, false);
            VerifyOutput(true, true, true);
        }

        private void VerifyOutput(bool input1, bool input2, bool expectedOutput)
        {
            _and.Fill(input1, input2);
            Assert.AreEqual(_and.Output, expectedOutput);
        }
    }
}
