using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;
using ComputingSystems.SeqLogic.Interfaces;

namespace ComputingSystems.SeqLogic
{
    public class Register : IClockedComponent
    {
        public Register()
        {
            // Initialise to false
            Input.AttachInput(false.ToPin());

            _mux.Fill(_dff.Output, Input, Load);
            _dff.Input.AttachInput(_mux.Output);
        }

        private readonly IMultiplexor _mux = TypeProvider.Get<IMultiplexor>();
        private readonly DataFlipFlop _dff = new DataFlipFlop();

        public bool Clock
        {
            get => _dff.Clock;
            set => _dff.Clock = value;
        }

        public IPin Input { get; } = new Pin();
        public IPin Load { get; } = new Pin();

        public IPin Output => _dff.Output;
    }
}
