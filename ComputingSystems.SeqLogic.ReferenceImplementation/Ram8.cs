using ComputingSystems.Core;
using ComputingSystems.SeqLogic.Interfaces;

namespace ComputingSystems.SeqLogic.ReferenceImplementation
{
    public class Ram8 : IRam8
    {
        public IBus Address { get; } = new Bus(3);
        public IPin Load { get; } = new Pin();
        public IBus Input { get; } = new Bus(16);

        public IBus Output { get; } = new Bus(16);

        private readonly bool[][] _values = BinaryUtils.EmptyArray(8, 16);

        private bool _clock = false;
        public bool Clock
        {
            get => _clock;
            set
            {
                if (_clock != value)
                {
                    Output.AttachInput(_values[BinaryUtils.BitsToInt(Address.ToBits(), 3)].ToBus());
                    if (Load.Value)
                    {
                        _values[BinaryUtils.BitsToInt(Address.ToBits(), 3)] = Input.ToBits();
                    }
                }

                _clock = value;
            }
        }
    }
}