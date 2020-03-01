using System.Linq;
using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;
using ComputingSystems.SeqLogic.Interfaces;

namespace ComputingSystems.SeqLogic
{
    public class Ram8 : IRam8
    {
        public Ram8()
        {
            _multiplexor.Fill(_registers.Select(r => r.Output.Pins).ToArray(), Address.Pins);

            _deMux.Selector.AttachInputs(Address.Pins);
            _deMux.Input.AttachInput(Load);

            for (var i = 0; i < _registers.Length; i++)
            {
                var register = _registers[i];
                register.Input.AttachInput(Input);
                register.Load.AttachInput(_deMux.Output[i]);
            }
        }

        private readonly NBitRegister[] _registers = Enumerable.Range(0, 8).Select(_ => new NBitRegister(16)).ToArray();
        private readonly IEightWaySixteenBitMultiplexor _multiplexor = TypeProvider.Get<IEightWaySixteenBitMultiplexor>();

        private readonly IEightWayDemultiplexor _deMux = TypeProvider.Get<IEightWayDemultiplexor>();

        public IBus Address { get; } = new Bus(3);

        public IPin Load { get; } = new Pin();
        public IBus Input { get; } = new Bus(16);

        private bool _clock;
        public bool Clock
        {
            get => _clock;
            set
            {
                _clock = value;
                foreach (var register in _registers)
                {
                    register.Clock = value;
                }
            }
        }

        public IBus Output => new Bus(_multiplexor.Output);

        public static Ram8[] ArrayOf(int count) => Enumerable.Range(0, 8).Select(_ => new Ram8()).ToArray();
    }
}