using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;
using ComputingSystems.SeqLogic.Interfaces;

namespace ComputingSystems.SeqLogic
{
    public class Register : IClockedComponent
    {
        private readonly IMultiplexor _mux = TypeProvider.Get<IMultiplexor>();
        private readonly DataFlipFlop _dff = new DataFlipFlop();

        public bool Clock
        {
            get => _dff.Clock;
            set
            {
                _mux.Fill(_dff.Output, Input, Load);
                _dff.Input = _mux.Output;
                _dff.Clock = value;
            }
        }

        public bool Input { get; set; }
        public bool Load { get; set; }

        public bool Output => _dff.Output;
    }
}
