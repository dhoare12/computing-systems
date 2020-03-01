using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;

namespace ComputingSystems.CombLogic
{
    public class Xor : IXor
    {
        public Xor()
        {
            _not1.Input.AttachInput(Input1);
            _not2.Input.AttachInput(Input2);
            _and1.Fill(Input1, _not2.Output);
            _and2.Fill(_not1.Output, Input2);
            _or.Fill(_and1.Output, _and2.Output);
        }
        private readonly IAnd _and1 = TypeProvider.Get<IAnd>();
        private readonly IAnd _and2 = TypeProvider.Get<IAnd>();
        private readonly INot _not1 = TypeProvider.Get<INot>();
        private readonly INot _not2 = TypeProvider.Get<INot>();
        private readonly IOr _or = TypeProvider.Get<IOr>();

        public IPin Input1 { get; } = new Pin();
        public IPin Input2 { get; } = new Pin();

        public IPin Output => _or.Output;

        public void Fill(IPin input1, IPin input2)
        {
            Input1.AttachInput(input1);
            Input2.AttachInput(input2);
        }
    }
}