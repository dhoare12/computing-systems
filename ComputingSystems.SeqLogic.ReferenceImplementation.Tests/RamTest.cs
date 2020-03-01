using System;
using ComputingSystems.Core;
using ComputingSystems.SeqLogic.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputingSystems.SeqLogic.ReferenceImplementation.Tests
{
    public class RamTest
    {
        private readonly RamTestHelper _ram;
        private readonly int _addressLength;
        private readonly int _maxValue;

        public RamTest(IRam ram, int addressLength)
        {
            _ram = new RamTestHelper(ram);
            _addressLength = addressLength;
            _maxValue = (int) Math.Pow(2, _addressLength);
        }

        public void Run()
        {
            for (var i = 0; i < _maxValue; i++)
            {
                _ram.Write(BinaryUtils.IntToBits(i, _addressLength), BinaryUtils.SixteenBitIntToBits(i + 10));
            }

            for (var i = 0; i < _maxValue; i++)
            {
                var value = _ram.Read(BinaryUtils.IntToBits(i, _addressLength));
                var intValue = BinaryUtils.SixteenBitBitsToInt(value);
                Assert.AreEqual(i + 10, intValue);
            }
        }
    }
}