using ComputingSystems.CombLogic.ReferenceImplementations;

namespace ComputingSystems.SeqLogic
{
    public class Register : IClockedComponent
    {
        private readonly Multiplexor _mux = new Multiplexor();
        private readonly DataFlipFlop _dff = new DataFlipFlop();

        public bool Clock
        {
            get => _dff.Clock;
            set
            {
                _mux.Fill(_dff.Out, In, Load);
                _dff.In = _mux.Output;
                _dff.Clock = value;
            }
        }

        public bool In { get; set; }
        public bool Load { get; set; }

        public bool Out => _dff.Out;
    }
}
