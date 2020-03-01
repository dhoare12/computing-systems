using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;

namespace ComputingSystems.CombLogic
{
    public class Not : INot
    {
        private readonly INand _nand = TypeProvider.Get<INand>();

        public Not()
        {
            _nand.Fill(Input, Input);
        }

        public IPin Input { get; } = new Pin();

        public IPin Output => _nand.Output;
        
        public void Fill(IPin input)
        {
            Input.AttachInput(input);
        }
    }
}