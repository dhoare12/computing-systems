using ComputingSystems.Core;
using ComputingSystems.SeqLogic.Interfaces;

namespace ComputingSystems.SeqLogic
{
    // I'm gonna assume this as already implemented
    // Could implement this with NAND latches and feedback loops
    public class DataFlipFlop : IClockedComponent
    {
        public DataFlipFlop()
        {
            // Initialise to false
            Output.AttachInput(false.ToPin());
        }

        private bool _clock;

        public bool Clock
        {
            get => _clock;
            set
            {
                if (_clock != value)
                {
                    _clock = value;
                    HandleClockTick();
                }
            }
        }

        public IPin Output { get; } = new Pin();

        public IPin Input { get; } = new Pin();

        private void HandleClockTick()
        {
            Output.AttachInput(Input.Value.ToPin());
        }
    }
}
