using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputingSystems.CombLogic.ReferenceImplementations.Tests
{
    [TestClass]
    public class EightWayDemultiplexorTests
    {
        private IEightWayDemultiplexor _demultiplexor;

        [TestMethod]
        public void EightWayDemultiplexorGateShouldBehaveCorrectly()
        {
            TestSetup.Setup();
            _demultiplexor = TypeProvider.Get<IEightWayDemultiplexor>();

            VerifyOutput(false, "000", "00000000");
            VerifyOutput(false, "001", "00000000");
            VerifyOutput(false, "010", "00000000");
            VerifyOutput(false, "011", "00000000");
            VerifyOutput(false, "100", "00000000");
            VerifyOutput(false, "101", "00000000");
            VerifyOutput(false, "110", "00000000");
            VerifyOutput(false, "111", "00000000");

            VerifyOutput(true, "000", "10000000");
            VerifyOutput(true, "001", "01000000");
            VerifyOutput(true, "010", "00100000");
            VerifyOutput(true, "011", "00010000");
            VerifyOutput(true, "100", "00001000");
            VerifyOutput(true, "101", "00000100");
            VerifyOutput(true, "110", "00000010");
            VerifyOutput(true, "111", "00000001");
        }

        private void VerifyOutput(bool input, string selector, string expectedOutput)
        {
            _demultiplexor.Input.AttachInput(input.ToPin());
            _demultiplexor.Selector.AttachInputs(selector.ToBinary().ToPins());
            Assert.AreEqual(_demultiplexor.Output.Values().ToBinaryString(), expectedOutput);
        }
    }
}
