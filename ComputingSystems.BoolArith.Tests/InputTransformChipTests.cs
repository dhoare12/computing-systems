using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputingSystems.BoolArith.ALU;
using ComputingSystems.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputingSystems.BoolArith.Tests
{
    [TestClass]
    public class InputTransformChipTests
    {
        private static readonly TwosComplementConverter TwosComplementConverter = new TwosComplementConverter();
        private static readonly IPin[] TwentySeven = TwosComplementConverter.SignedIntToBits(27, 16).Select(x => new ValuePin(x)).ToArray();
        private static readonly IPin[] Zero = TwosComplementConverter.SignedIntToBits(0, 16).Select(x => new ValuePin(x)).ToArray();
        private static readonly IPin True = new ValuePin(true);
        private static readonly IPin False = new ValuePin(false);
        
        [TestMethod]
        public void NoTransformBehavesCorrectly()
        {
            var chip = new InputTransformChip();

            chip.Fill(False, False, TwentySeven);

            for (var i = 0; i < chip.Output.Length; i++)
            {
                Assert.AreEqual(chip.Output[i].Value, TwentySeven[i].Value);
            }
        }

        [TestMethod]
        public void ZeroTransformBehavesCorrectly()
        {
            var chip = new InputTransformChip();

            chip.Fill(True, False, TwentySeven);

            for (var i = 0; i < chip.Output.Length; i++)
            {
                Assert.AreEqual(chip.Output[i].Value, Zero[i].Value);
            }
        }

        [TestMethod]
        public void NegateTransformBehavesCorrectly()
        {
            var chip = new InputTransformChip();

            chip.Fill(False, True, TwentySeven);

            for (var i = 0; i < chip.Output.Length; i++)
            {
                Assert.AreEqual(chip.Output[i].Value, !TwentySeven[i].Value);
            }
        }

        [TestMethod]
        public void BothTransformBehavesCorrectly()
        {
            var chip = new InputTransformChip();

            chip.Fill(True, True, TwentySeven);

            for (var i = 0; i < chip.Output.Length; i++)
            {
                Assert.AreEqual(chip.Output[i].Value, !Zero[i].Value);
            }
        }
    }
}
