using ComputingSystems.Core;
using ComputingSystems.SeqLogic.Interfaces;

namespace ComputingSystems.SeqLogic.ReferenceImplementation
{
    public class Ram512 : IRam512
    {
        public bool[] Address { get; set; }
        public bool Load { get; set; }
        public bool[] Input { get; set; }

        public bool[] Output { get; private set; } = BinaryUtils.EmptyArray(16);

        private readonly bool[][] _values = BinaryUtils.EmptyArray(512, 16);

        private bool _clock;
        public bool Clock
        {
            get => _clock;
            set
            {
                if (_clock != value)
                {
                    Output = _values[BinaryUtils.BitsToInt(Address, 9)];
                    if (Load)
                    {
                        _values[BinaryUtils.BitsToInt(Address, 9)] = Input;
                    }
                }

                _clock = value;
            }
        }
    }
}