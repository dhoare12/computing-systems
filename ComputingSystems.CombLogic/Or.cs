using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;

namespace ComputingSystems.CombLogic
{
    public class Or : IOr
    {
        public Or()
        {
            _not1.Input.AttachInput(Input1);
            _not2.Input.AttachInput(Input2);
            _nand.Fill(_not1.Output, _not2.Output);
        }
        private readonly INot _not1 = TypeProvider.Get<INot>();
        private readonly INot _not2 = TypeProvider.Get<INot>();
        private readonly INand _nand = TypeProvider.Get<INand>();
        
        public IPin Input1 { get; } = new Pin();
        public IPin Input2 { get; } = new Pin();

        public IPin Output => _nand.Output;

        public void Fill(IPin input1, IPin input2)
        {
            Input1.AttachInput(input1);
            Input2.AttachInput(input2);
        }
    }
}