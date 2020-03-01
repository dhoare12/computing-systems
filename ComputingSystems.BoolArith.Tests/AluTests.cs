using System.Linq;
using ComputingSystems.BoolArith.ALU;
using ComputingSystems.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputingSystems.BoolArith.Tests
{
    [TestClass]
    public class AluTests
    {
        private static readonly TwosComplementConverter TwosComplement = new TwosComplementConverter();

        [TestMethod]
        public void ZeroFunction()
        {
            var alu = new Alu().WithValues(flags: "101010", x: 10, y: 20);

            Assert.AreEqual(TwosComplement.BitsToSignedInt(alu.Out.Select(x => x.Value).ToArray()), 0);
            Assert.AreEqual(alu.Zr.Value, true);
            Assert.AreEqual(alu.Ng.Value, false);
        }

        [TestMethod]
        public void OneFunction()
        {
            var alu = new Alu().WithValues(flags: "111111", x: 10, y: 20);

            Assert.AreEqual(1, TwosComplement.BitsToSignedInt(alu.Out.Select(x => x.Value).ToArray()));
            Assert.AreEqual(false, alu.Zr.Value);
            Assert.AreEqual(false, alu.Ng.Value);
        }

        [TestMethod]
        public void NegativeOneFunction()
        {
            var alu = new Alu().WithValues(flags: "111010", x: 10, y: 20);

            Assert.AreEqual(-1, TwosComplement.BitsToSignedInt(alu.Out.Select(x => x.Value).ToArray()));
            Assert.AreEqual(false, alu.Zr.Value);
            Assert.AreEqual(true, alu.Ng.Value);
        }

        [TestMethod]
        public void XFunction()
        {
            var alu = new Alu().WithValues(flags: "001100", x: 10, y: 20);

            Assert.AreEqual(10, TwosComplement.BitsToSignedInt(alu.Out.Select(x => x.Value).ToArray()));
            Assert.AreEqual(false, alu.Zr.Value);
            Assert.AreEqual(false, alu.Ng.Value);
        }

        [TestMethod]
        public void YFunction()
        {
            var alu = new Alu().WithValues(flags: "110000", x: 10, y: 20);

            Assert.AreEqual(20, TwosComplement.BitsToSignedInt(alu.Out.Select(x => x.Value).ToArray()));
            Assert.AreEqual(false, alu.Zr.Value);
            Assert.AreEqual(false, alu.Ng.Value);
        }

        [TestMethod]
        public void NotXFunction()
        {
            var alu = new Alu().WithValues(flags: "001101", x: 10, y: 20);

            Assert.AreEqual(-11, TwosComplement.BitsToSignedInt(alu.Out.Select(x => x.Value).ToArray()));
            Assert.AreEqual(false, alu.Zr.Value);
            Assert.AreEqual(true, alu.Ng.Value);
        }

        [TestMethod]
        public void NotYFunction()
        {
            var alu = new Alu().WithValues(flags: "110001", x: 10, y: 20);

            Assert.AreEqual(-21, TwosComplement.BitsToSignedInt(alu.Out.Select(x => x.Value).ToArray()));
            Assert.AreEqual(false, alu.Zr.Value);
            Assert.AreEqual(true, alu.Ng.Value);
        }

        [TestMethod]
        public void MinusXFunction()
        {
            var alu = new Alu().WithValues(flags: "001111", x: 10, y: 20);

            Assert.AreEqual(-10, TwosComplement.BitsToSignedInt(alu.Out.Select(x => x.Value).ToArray()));
            Assert.AreEqual(false, alu.Zr.Value);
            Assert.AreEqual(true, alu.Ng.Value);
        }

        [TestMethod]
        public void MinusYFunction()
        {
            var alu = new Alu().WithValues(flags: "110011", x: 10, y: 20);

            Assert.AreEqual(-20, TwosComplement.BitsToSignedInt(alu.Out.Select(x => x.Value).ToArray()));
            Assert.AreEqual(false, alu.Zr.Value);
            Assert.AreEqual(true, alu.Ng.Value);
        }

        [TestMethod]
        public void XPlusOneFunction()
        {
            var alu = new Alu().WithValues(flags: "011111", x: 10, y: 20);

            Assert.AreEqual(11, TwosComplement.BitsToSignedInt(alu.Out.Select(x => x.Value).ToArray()));
            Assert.AreEqual(false, alu.Zr.Value);
            Assert.AreEqual(false, alu.Ng.Value);
        }

        [TestMethod]
        public void YPlusOneFunction()
        {
            var alu = new Alu().WithValues(flags: "110111", x: 10, y: 20);

            Assert.AreEqual(21, TwosComplement.BitsToSignedInt(alu.Out.Select(x => x.Value).ToArray()));
            Assert.AreEqual(false, alu.Zr.Value);
            Assert.AreEqual(false, alu.Ng.Value);
        }

        [TestMethod]
        public void XMinusOneFunction()
        {
            var alu = new Alu().WithValues(flags: "001110", x: 10, y: 20);

            Assert.AreEqual(9, TwosComplement.BitsToSignedInt(alu.Out.Select(x => x.Value).ToArray()));
            Assert.AreEqual(false, alu.Zr.Value);
            Assert.AreEqual(false, alu.Ng.Value);
        }

        [TestMethod]
        public void YMinusOneFunction()
        {
            var alu = new Alu().WithValues(flags: "110010", x: 10, y: 20);

            Assert.AreEqual(19, TwosComplement.BitsToSignedInt(alu.Out.Select(x => x.Value).ToArray()));
            Assert.AreEqual(false, alu.Zr.Value);
            Assert.AreEqual(false, alu.Ng.Value);
        }

        [TestMethod]
        public void XPlusYFunction()
        {
            var alu = new Alu().WithValues(flags: "000010", x: 10, y: 20);

            Assert.AreEqual(30, TwosComplement.BitsToSignedInt(alu.Out.Select(x => x.Value).ToArray()));
            Assert.AreEqual(false, alu.Zr.Value);
            Assert.AreEqual(false, alu.Ng.Value);
        }

        [TestMethod]
        public void XMinusYFunctionFunction()
        {
            var alu = new Alu().WithValues(flags: "010011", x: 10, y: 20);

            Assert.AreEqual(-10, TwosComplement.BitsToSignedInt(alu.Out.Select(x => x.Value).ToArray()));
            Assert.AreEqual(false, alu.Zr.Value);
            Assert.AreEqual(true, alu.Ng.Value);
        }

        [TestMethod]
        public void YMinusXFunction()
        {
            var alu = new Alu().WithValues(flags: "000111", x: 10, y: 20);

            Assert.AreEqual(10, TwosComplement.BitsToSignedInt(alu.Out.Select(x => x.Value).ToArray()));
            Assert.AreEqual(false, alu.Zr.Value);
            Assert.AreEqual(false, alu.Ng.Value);
        }

        [TestMethod]
        public void XAndYFunction()
        {
            var alu = new Alu().WithValues(flags: "000000", x: 10, y: 22);

            Assert.AreEqual(2, TwosComplement.BitsToSignedInt(alu.Out.Select(x => x.Value).ToArray()));
            Assert.AreEqual(false, alu.Zr.Value);
            Assert.AreEqual(false, alu.Ng.Value);
        }

        [TestMethod]
        public void XOrYFunction()
        {
            var alu = new Alu().WithValues(flags: "010101", x: 10, y: 22);

            Assert.AreEqual(30, TwosComplement.BitsToSignedInt(alu.Out.Select(x => x.Value).ToArray()));
            Assert.AreEqual(false, alu.Zr.Value);
            Assert.AreEqual(false, alu.Ng.Value);
        }
    }

    public static class AluExtensions
    {
        private static readonly TwosComplementConverter TwosComplement = new TwosComplementConverter();
        public static Alu WithValues(this Alu alu, string flags, int x, int y)
        {
            var flagBits = flags.ToCharArray()
                .Select(b => new ValuePin(b == '1'))
                .ToArray();

            var xPins = TwosComplement.SignedIntToBits(x, 16).Select(v => new ValuePin(v)).ToArray();
            var yPins = TwosComplement.SignedIntToBits(y, 16).Select(v => new ValuePin(v)).ToArray();
            
            alu.Fill(flagBits[0], flagBits[1], flagBits[2], flagBits[3], flagBits[4], flagBits[5], xPins, yPins);

            return alu;
        }
    }
}
