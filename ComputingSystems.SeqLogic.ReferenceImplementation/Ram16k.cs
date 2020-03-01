using System.Linq;
using ComputingSystems.Core;
using ComputingSystems.SeqLogic.Interfaces;

namespace ComputingSystems.SeqLogic.ReferenceImplementation
{
    public class Ram16k : IRam16k
    {
        public IBus Address { get; } = new Bus(14);
        public IPin Load { get; } = new Pin();
        public IBus Input { get; } = new Bus(16);
        public IBus Output => new ValueBus(16, _currentValue);

        private bool[] _currentValue;

        private readonly bool[][] _values = BinaryUtils.EmptyArray(16384, 16);

        private bool _clock;
        public bool Clock
        {
            get => _clock;
            set
            {
                if (_clock != value)
                {
                    var address = BinaryUtils.BitsToInt(Address.Pins.Select(x => x.Value).ToArray(), 14);
                    _currentValue = _values[address];
                    if (Load.Value)
                    {
                        _values[address] = Input.Pins.Select(x => x.Value).ToArray();
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