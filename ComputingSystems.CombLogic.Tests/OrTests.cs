using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputingSystems.CombLogic.ReferenceImplementations.Tests
{
    [TestClass]
    public class OrTests
    {
        private IOr _or;

        [TestMethod]
        public void OrGateShouldBehaveCorrectly()
        {
            TestSetup.Setup();
            _or = TypeProvider.Get<IOr>();

            VerifyOutput(false, false, false);
            VerifyOutput(false, true, true);
            VerifyOutput(true, false, true);
            VerifyOutput(true, true, true);
        }

        private void VerifyOutput(bool input1, bool input2, bool expectedOutput)
        {
            _or.Fill(input1, input2);
            Assert.AreEqual(_or.Output, expectedOutput);
        }
    }
}
