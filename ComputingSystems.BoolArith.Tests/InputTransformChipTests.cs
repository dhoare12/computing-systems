using System;
using System.Collections.Generic;
using System.Text;
using ComputingSystems.BoolArith.ALU;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputingSystems.BoolArith.Tests
{
    [TestClass]
    public class InputTransformChipTests
    {
        private static readonly TwosComplementConverter TwosComplementConverter = new TwosComplementConverter();
        private static readonly bool[] TwentySeven = TwosComplementConverter.SignedIntToBits(27, 16);
        private static readonly bool[] Zero = TwosComplementConverter.SignedIntToBits(0, 16);
        
        [TestMethod]
        public void NoTransformBehavesCorrectly()
        {
            var chip = new InputTransformChip();

            chip.Fill(false, false, TwentySeven);

            for (var i = 0; i < chip.Output.Length; i++)
            {
                Assert.AreEqual(chip.Output[i], TwentySeven[i]);
            }
        }

        [TestMethod]
        public void ZeroTransformBehavesCorrectly()
        {
            var chip = new InputTransformChip();

            chip.Fill(true, false, TwentySeven);

            for (var i = 0; i < chip.Output.Length; i++)
            {
                Assert.AreEqual(chip.Output[i], Zero[i]);
            }
        }

        [TestMethod]
        public void NegateTransformBehavesCorrectly()
        {
            var chip = new InputTransformChip();

            chip.Fill(false, true, TwentySeven);

            for (var i = 0; i < chip.Output.Length; i++)
            {
                Assert.AreEqual(chip.Output[i], !TwentySeven[i]);
            }
        }

        [TestMethod]
        public void BothTransformBehavesCorrectly()
        {
            var chip = new InputTransformChip();

            chip.Fill(true, true, TwentySeven);

            for (var i = 0; i < chip.Output.Length; i++)
            {
                Assert.AreEqual(chip.Output[i], !Zero[i]);
            }
        }
    }
}
