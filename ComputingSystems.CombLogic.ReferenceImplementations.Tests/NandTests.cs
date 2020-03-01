using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputingSystems.CombLogic.ReferenceImplementations.Tests
{
    [TestClass]
    public class NandTests
    {
        private INand _nand;

        [TestMethod]
        public void NandGateShouldBehaveCorrectly()
        {
            TestSetup.Setup();
            _nand = TypeProvider.Get<INand>();

            VerifyOutput(false, false, true);
            VerifyOutput(false, true, true);
            VerifyOutput(true, false, true);
            VerifyOutput(true, true, false);
        }

        private void VerifyOutput(bool input1, bool input2, bool expectedOutput)
        {
            _nand.Input1.AttachInput(input1.ToPin());
            _nand.Input2.AttachInput(input2.ToPin());
            Assert.AreEqual(_nand.Output.Value, expectedOutput);
        }
    }
}