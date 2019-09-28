using System;
using System.Linq;
using ComputingSystems.Core;
using ComputingSystems.SeqLogic.Interfaces;

namespace ComputingSystems.SeqLogic.ReferenceImplementation
{
    public class SixteenBitCounter : IClockedComponent
    {
        private bool[] _valueInner = Enumerable.Range(0, 16).Select(_ => false).ToArray();

        public bool[] In { get; set; }
        public bool Inc { get; set; }
        public bool Load { get; set; }
        public bool Reset { get; set; }

        public bool[] Out => _valueInner;

        public bool Clock
        {
            get => throw new NotImplementedException();
            set
            {
                if (Reset)
                {
                    _valueInner = Enumerable.Range(0, 16).Select(_ => false).ToArray();
                }
                else if (Load)
                {
                    _valueInner = In;
                }
                else if (Inc)
                {
                    _valueInner = BinaryUtils.SixteenBitIntToBits(BinaryUtils.BitsToInt(_valueInner, 16) + 1);
                }
            }
        }
    }
}
