using ComputingSystems.Core;
using ComputingSystems.SeqLogic.Interfaces;

namespace ComputingSystems.SeqLogic.ReferenceImplementation
{
    public class Ram16k : IRam16k
    {
        public bool[] Address { get; set; } = BinaryUtils.FifteenBitIntToBits(0);
        public bool Load { get; set; }
        public bool[] Input { get; set; } = BinaryUtils.SixteenBitIntToBits(0);

        public bool[] Output { get; private set; } = BinaryUtils.EmptyArray(16);

        private readonly bool[][] _values = BinaryUtils.EmptyArray(16384, 16);

        private bool _clock;
        public bool Clock
        {
            get => _clock;
            set
            {
                if (_clock != value)
                {
                    var address = BinaryUtils.BitsToInt(Address, 15);
                    Output = _values[address];
                    if (Load)
                    {
                        _values[address] = Input;
                    }
                }

                _clock = value;
            }
        }

        public void Preload(bool[][] values)
        {
            for (var i = 0; i < values.Length; i++)
            {
                _values[i] = values[i];
            }
        }

        public int GetDataValue(int address)
        {
            return BinaryUtils.BitsToInt(_values[address], 16);
        }

        public void SetDataValue(int address, int val)
        {
            _values[address] = BinaryUtils.IntToBits(val, 16);
        }
    }
}