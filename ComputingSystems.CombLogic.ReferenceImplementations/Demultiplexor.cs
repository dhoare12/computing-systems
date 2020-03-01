using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;

namespace ComputingSystems.CombLogic.ReferenceImplementations
{
    public class Demultiplexor : IDemultiplexor
    {
        public Demultiplexor()
        {
            Output1 = new ValuePin(() => !Selector.Value && Input.Value);
            Output2 =  new ValuePin(() => Selector.Value && Input.Value);
        }
        public IPin Input { get; } = new Pin();
        public IPin Selector { get; } = new Pin();

        public IPin Output1 { get; }
        public IPin Output2 { get; }

        public void Fill(IPin input, IPin selector)
        {
            Input.AttachInput(input);
            Selector.AttachInput(selector);
        }
    }
}