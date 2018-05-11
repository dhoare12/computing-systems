using System;

namespace ComputingSystems.SeqLogic
{
    public interface IClockedComponent
    {
        bool Clock { get; set; }
    }

    // I'm gonna assume this as already implemented
    // Could implement this with NAND latches and feedback loops
    public class DataFlipFlop : IClockedComponent
    {
        private bool _clock = false;
        private bool _value = false;
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

        public bool Out => _value;

        public bool In { get; set; }

        private void HandleClockTick()
        {
            _value = In;
        }
    }
}
