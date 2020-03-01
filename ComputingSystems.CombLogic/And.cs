using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;

namespace ComputingSystems.CombLogic
{
    public class And : IAnd
    {
        public And()
        {
            _nand.Fill(Input1, Input2);
            _not.Input.AttachInput(_nand.Output);
        }
        private readonly INand _nand = TypeProvider.Get<INand>();
        private readonly INot _not = TypeProvider.Get<INot>();

        public IPin Input1 { get; } = new Pin();
        public IPin Input2 { get; } = new Pin();

        public IPin Output => _not.Output;

        public void Fill(IPin input1, IPin input2)
        {
            Input1.AttachInput(input1);
            Input2.AttachInput(input2);
        }

        public override string ToString() => Output.Value ? "1" : "0";
    }
}