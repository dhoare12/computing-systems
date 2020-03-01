using ComputingSystems.Core;
using ComputingSystems.SeqLogic.Interfaces;

namespace ComputingSystems.SeqLogic.ReferenceImplementation
{
    public class Ram512 : IRam512
    {
        public IBus Address { get; } = new Bus(9);
        public IPin Load { get; } = new Pin();
        public IBus Input { get; } = new Bus(16);

        public IBus Output { get; } = new Bus(16);

        private readonly bool[][] _values = BinaryUtils.EmptyArray(512, 16);

        private bool _clock;
        public bool Clock
        {
            get => _clock;
            set
            {
                if (_clock != value)
                {
                    Output.AttachInput(_values[BinaryUtils.BitsToInt(Address.ToBits(), 9)].ToBus());
                    if (Load.Value)
                    {
                        _values[BinaryUtils.BitsToInt(Address.ToBits(), 9)] = Input.ToBits();
                    }
                }

                _clock = value;
            }
        }
    }
}