using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;

namespace ComputingSystems.CombLogic.ReferenceImplementations
{
    public class Multiplexor : IMultiplexor
    {
        public Multiplexor()
        {
            Output = new ValuePin(() => Selector.Value ? Input2.Value : Input1.Value);
        }

        public IPin Input1 { get; } = new Pin();
        public IPin Input2 { get; } = new Pin();
        public IPin Selector { get; } = new Pin();
        public IPin Output { get; }

        public void Fill(IPin input1, IPin input2, IPin selector)
        {
            Input1.AttachInput(input1);
            Input2.AttachInput(input2);
            Selector.AttachInput(selector);
        }
    }

    public class SixteenBitMultiplexor
    {
        public SixteenBitMultiplexor()
        {
            Output = new ValueBus(16, x => Selector.Value ? Input2.Pins[x].Value : Input1.Pins[x].Value);
        }

        public IBus Input1 { get; } = new Bus(16);
        public IBus Input2 { get; } = new Bus(16);
        public IPin Selector { get; } = new Pin();
        public IBus Output {get; }

        public void Fill(IBus input1, IBus input2, IPin selector)
        {
            Input1.AttachInput(input1);
            Input2.AttachInput(input2);
            Selector.AttachInput(selector);
        }
    }
}