using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputingSystems.CombLogic.ReferenceImplementations.Tests
{
    [TestClass]
    public class NotTests
    {
        private INot _not;

        [TestMethod]
        public void NotGateShouldBehaveCorrectly()
        {
            TestSetup.Setup();
            _not = TypeProvider.Get<INot>();

            VerifyOutput(false, true);
            VerifyOutput(true, false);
        }

        private void VerifyOutput(bool input, bool expectedOutput)
        {
            _not.Input.AttachInput(input.ToPin());
            Assert.AreEqual(_not.Output.Value, expectedOutput);
        }
    }
}