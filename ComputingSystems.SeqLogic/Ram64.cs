using System.Linq;
using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;
using ComputingSystems.SeqLogic.Interfaces;

namespace ComputingSystems.SeqLogic
{
    public class Ram64 : IRam64
    {
        private readonly Ram8[] _ram = Ram8.ArrayOf(8);
        private readonly IEightWaySixteenBitMultiplexor _mux = TypeProvider.Get<IEightWaySixteenBitMultiplexor>();
        private readonly IEightWayDemultiplexor _demux = TypeProvider.Get<IEightWayDemultiplexor>();

        public IBus Address { get; } = new Bus(6); // Six bits
        private IPin[] AddressMostSignificant => new[] {Address.Pins[0], Address.Pins[1], Address.Pins[2]};
        private IPin[] AddressLeastSignificant => new[] {Address.Pins[3], Address.Pins[4], Address.Pins[5]};

        public IBus Input { get; } = new Bus(16);

        public IPin Load { get; } = new Pin();

        public IBus Output => new Bus(_mux.Output);

        private bool _clock;
        public bool Clock
        {
            get => _clock;
            set
            {
                foreach (var ram in _ram)
                {
                    ram.Address.AttachInput(new Bus(AddressLeastSignificant));
                    ram.Input.AttachInput(Input);
                    ram.Load.AttachInput(false.ToPin());
                }

                _demux.Selector.AttachInputs(AddressMostSignificant);
                _demux.Input.AttachInput(Load);

                for (var i = 0; i < _ram.Length; i++)
                {
                    _ram[i].Input.AttachInput(Input);
                    _ram[i].Load.AttachInput(_demux.Output[i]);
                }

                _clock = value;

                foreach (var ram in _ram)
                {
                    ram.Clock = value;
                }

                for (var i = 0; i < 8; i++)
                {
                    _mux.Input[i].AttachInputs(_ram[i].Output.Pins);
                }
                _mux.Selector.AttachInputs(AddressMostSignificant);
            }
        }

        public static Ram64[] ArrayOf(int count) => Enumerable.Range(0, count).Select(_ => new Ram64()).ToArray();
    }
}