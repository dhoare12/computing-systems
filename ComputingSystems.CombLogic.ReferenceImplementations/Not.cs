using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;

namespace ComputingSystems.CombLogic.ReferenceImplementations
{
    public class Not
    {
        public Not()
        {
            Output = new ValuePin(() => !Input.Value);
        }

        public IPin Input = new Pin();
        public IPin Output;
    }
}