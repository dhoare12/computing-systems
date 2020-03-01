using System.Linq;
using ComputingSystems.Core;
using ComputingSystems.SeqLogic.Interfaces;

namespace ComputingSystems.SeqLogic
{
    public class NBitRegister : IClockedComponent
    {
        private readonly Register[] _registers;
        public NBitRegister(int width)
        {
            _registers = Enumerable.Range(0, width).Select(_ => new Register()).ToArray();
            Input = new Bus(width);
        }

        public IBus Input { get; }
        public IPin Load { get; } = new Pin();

        private bool _clock;
        public bool Clock
        {
            get => _clock;
            set
            {
                _clock = value;
                for (var i = 0; i < _registers.Length; i++)
                {
                    _registers[i].Input.AttachInput(Input.Pins[i]);
                    _registers[i].Load.AttachInput(Load);
                    _registers[i].Clock = value;
                }
            }
        }

        public IBus Output => new ValueBus(_registers.Length, _registers.Select(r => r.Output.Value).ToArray());

        public override string ToString()
        {
            return _registers.Select(r => r.Output.Value).ToArray().ToBinaryString();
        }
    }
}
