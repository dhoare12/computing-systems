using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;

namespace ComputingSystems.CombLogic
{
    public class Demultiplexor : IDemultiplexor
    {
        public Demultiplexor()
        {
            _not.Input.AttachInput(Selector);
            _and1.Fill(Input, _not.Output);
            _and2.Fill(Input, Selector);
        }

        private readonly IAnd _and1 = TypeProvider.Get<IAnd>(), _and2 = TypeProvider.Get<IAnd>();
        private readonly INot _not = new Not();

        public IPin Input { get; } = new Pin();
        public IPin Selector { get; } = new Pin();

        public IPin Output1 => _and1.Output;

        public IPin Output2 => _and2.Output;

        public void Fill(IPin input, IPin selector)
        {
            Input.AttachInput(input);
            Selector.AttachInput(selector);
        }
    }
}