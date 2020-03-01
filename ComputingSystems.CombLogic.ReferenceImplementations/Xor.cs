using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;

namespace ComputingSystems.CombLogic.ReferenceImplementations
{
    public class Xor : IXor
    {
        public Xor()
        {
            Output = new ValuePin(() => (Input1.Value || Input2.Value) && !(Input1.Value && Input2.Value));
        }

        public IPin Input1 { get; } = new Pin();
        public IPin Input2 { get; } = new Pin();
        public IPin Output { get; }

        public void Fill(IPin input1, IPin input2)
        {
            Input1.AttachInput(input1);
            Input2.AttachInput(input2);
        }
    }
}