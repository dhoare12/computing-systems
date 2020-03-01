using System.Linq;
using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputingSystems.CombLogic.Tests
{
    [TestClass]
    public class EightWaySixteenBitMultiplexorTests
    {
        private IEightWaySixteenBitMultiplexor _multiplexor;
        private static readonly int[] TestInput = new[] {7, 14, 21, 28, 35, 42, 49, 56};

        [TestMethod]
        public void EightWaySixteenBitMultiplexorGateShouldBehaveCorrectly()
        {
            TestSetup.Setup();
            _multiplexor = TypeProvider.Get<IEightWaySixteenBitMultiplexor>();

            VerifyOutput("000", 7);
            VerifyOutput("001", 14);
            VerifyOutput("010", 21);
            VerifyOutput("011", 28);
            VerifyOutput("100", 35);
            VerifyOutput("101", 42);
            VerifyOutput("110", 49);
            VerifyOutput("111", 56);
        }

        private void VerifyOutput(string selector, int expectedOutput)
        {
            var inputs = TestInput.Select(BinaryUtils.SixteenBitIntToBits).ToArray();

            for (var i = 0; i < 8; i++)
            {
                _multiplexor.Input[i].AttachInputs(inputs[i].ToPins());
            }
            
            _multiplexor.Selector.AttachInputs(selector.ToBinary().ToPins());
            Assert.AreEqual(BinaryUtils.SixteenBitBitsToInt(_multiplexor.Output.Values()), expectedOutput);
        }
    }
}