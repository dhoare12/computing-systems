using ComputingSystems.SeqLogic.Interfaces;

namespace ComputingSystems.SeqLogic
{
    // I'm gonna assume this as already implemented
    // Could implement this with NAND latches and feedback loops
    public class DataFlipFlop : IClockedComponent
    {
        private bool _clock = false;

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

        public bool Output { get; private set; } = false;

        public bool Input { get; set; }

        private void HandleClockTick()
        {
            Output = Input;
        }
    }
}
