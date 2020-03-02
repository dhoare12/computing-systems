using System;
using System.Linq;
using ComputingSystems.Core;
using ComputingSystems.SeqLogic.Interfaces;

namespace ComputingSystems.SeqLogic.ReferenceImplementation
{
    public class NBitCounter : IClockedComponent
    {
        private readonly int _bits;

        public NBitCounter(int bits)
        {
            _bits = bits;
            In = new Bus(bits);
            Out = new Bus(16);
            Out.AttachInput("0000 0000 0000 0000".ToBinary().ToBus());
        }

        public IBus In { get; }
        public IPin Inc { get; } = new Pin();
        public IPin Load { get; } = new Pin(false.ToPin());
        public IPin Reset { get; } = new Pin(false.ToPin());

        public IBus Out { get; private set; }

        public bool Clock
        {
            get => throw new NotImplementedException();
            set
            {
                if (Reset.Value)
                {
                    Out = new ValueBus(16, Enumerable.Range(0, _bits).Select(_ => false).ToArray());
                }
                else if (Load.Value)
                {
                    Out = new ValueBus(16, Enumerable.Range(0, _bits).Select(x => In.Pins[x].Value).ToArray());
                }
                else if (Inc.Value)
                {
                    var outBits = BinaryUtils.IntToBits(BinaryUtils.BitsToInt(Out.Pins.Select(x => x.Value).ToArray(), _bits) + 1, _bits);
                    Out = new ValueBus(16, outBits);
                }
            }
        }
    }
}
