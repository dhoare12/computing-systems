using System.Linq;

namespace ComputingSystems.SeqLogic
{
    public class NBitRegister : IClockedComponent
    {
        private readonly Register[] _registers;
        public NBitRegister(int width)
        {
            _registers = Enumerable.Range(0, width).Select(_ => new Register()).ToArray();
        }

        public bool[] Inputs { get; set; }
        public bool Load { get; set; }

        private bool _clock;
        public bool Clock
        {
            get => _clock;
            set
            {
                _clock = value;
                for (var i = 0; i < _registers.Length; i++)
                {
                    _registers[i].In = Inputs[i];
                    _registers[i].Load = Load;
                    _registers[i].Clock = value;
                }
            }
        }

        public bool[] Outputs => _registers.Select(r => r.Out).ToArray();

        public override string ToString()
        {
            return _registers.Select(r => r.Out).ToArray().ToBinaryString();
        }
    }
}
