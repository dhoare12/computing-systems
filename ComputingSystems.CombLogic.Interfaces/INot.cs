using ComputingSystems.Core;

namespace ComputingSystems.CombLogic.Interfaces
{
    public interface INot
    {
        IPin Input { get; }
        IPin Output { get; }

        void Fill(IPin input);
    }
}