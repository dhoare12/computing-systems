using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;

namespace ComputingSystems.CombLogic.ReferenceImplementations
{
    public class Not : INot
    {
        public Not()
        {
            Output = new ValuePin(() => !Input.Value);
        }

        public void Fill(IPin input) => Input.AttachInput(input);

        public IPin Input { get; } = new Pin();
        public IPin Output { get; }
    }
}