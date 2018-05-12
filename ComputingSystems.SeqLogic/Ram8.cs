using System.Linq;
using ComputingSystems.CombLogic.ReferenceImplementations;

namespace ComputingSystems.SeqLogic
{
    public class Ram8 : IClockedComponent
    {
        private readonly NBitRegister[] _registers = Enumerable.Range(0, 8).Select(_ => new NBitRegister(16)).ToArray();
        private readonly EightWaySixteenBitMultiplexor _multiplexor = new EightWaySixteenBitMultiplexor();

        private readonly EightWayDemultiplexor _deMux = new EightWayDemultiplexor();

        public bool[] Address { get; set; }

        public bool Load { get; set; }
        public bool[] In { get; set; }

        private bool _clock;
        public bool Clock
        {
            get => _clock;
            set
            {
                _multiplexor.Inputs = _registers.Select(r => r.Outputs).ToArray();
                _multiplexor.Selector = Address;
                
                foreach (var register in _registers)
                {
                    register.Inputs = In;
                    register.Load = false;
                }

                _deMux.Selector = Address;
                _deMux.Input = Load;

                for (var i = 0; i < _registers.Length; i++)
                {
                    _registers[i].Inputs = In;
                    _registers[i].Load = _deMux.Outputs[i];
                }

                _clock = value;
                foreach (var register in _registers)
                {
                    register.Clock = value;
                }
            }
        }

        public bool[] Out => _multiplexor.Output;

        public static Ram8[] ArrayOf(int count) => Enumerable.Range(0, 8).Select(_ => new Ram8()).ToArray();
    }
}