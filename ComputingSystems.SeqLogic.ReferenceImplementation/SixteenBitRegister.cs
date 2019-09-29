using System;
using System.Linq;
using ComputingSystems.Core;
using ComputingSystems.SeqLogic.Interfaces;

namespace ComputingSystems.SeqLogic.ReferenceImplementation
{
    public class SixteenBitRegister : IClockedComponent
    {
        public SixteenBitRegister()
        {
            Output = new Bus(16);
        }

        public bool Clock
        {
            get => throw new NotImplementedException();
            set
            {
                if (Load.Value)
                {
                    if (Input.Width < 16)
                    {
                        Output = new ValueBus(16, Enumerable.Range(0, 16 - Input.Width).Select(_ => false).Concat(Input.Pins.Select(x => x.Value)).ToArray());
                    } 
                    else
                    {
                        Output = new ValueBus(16, Input.Pins.Select(p => p.Value).ToArray());
                    }
                }
            }
        }

        public IBus Input { get; } = new Bus(16);

        public IPin Load { get; } = new Pin();

        public IBus Output { get; private set; }
    }
}
