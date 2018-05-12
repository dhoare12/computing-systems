using System.Linq;
using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;
using ComputingSystems.SeqLogic.Interfaces;

namespace ComputingSystems.SeqLogic
{
    public class Ram8 : IRam8
    {
        private readonly NBitRegister[] _registers = Enumerable.Range(0, 8).Select(_ => new NBitRegister(16)).ToArray();
        private readonly IEightWaySixteenBitMultiplexor _multiplexor = TypeProvider.Get<IEightWaySixteenBitMultiplexor>();

        private readonly IEightWayDemultiplexor _deMux = TypeProvider.Get<IEightWayDemultiplexor>();

        public bool[] Address { get; set; }

        public bool Load { get; set; }
        public bool[] Input { get; set; }

        private bool _clock;
        public bool Clock
        {
            get => _clock;
            set
            {
                _multiplexor.Input = _registers.Select(r => r.Output).ToArray();
                _multiplexor.Selector = Address;
                
                foreach (var register in _registers)
                {
                    register.Input = Input;
                    register.Load = false;
                }

                _deMux.Selector = Address;
                _deMux.Input = Load;

                for (var i = 0; i < _registers.Length; i++)
                {
                    _registers[i].Input = Input;
                    _registers[i].Load = _deMux.Output[i];
                }

                _clock = value;
                foreach (var register in _registers)
                {
                    register.Clock = value;
                }
            }
        }

        public bool[] Output => _multiplexor.Output;

        public static Ram8[] ArrayOf(int count) => Enumerable.Range(0, 8).Select(_ => new Ram8()).ToArray();
    }
}