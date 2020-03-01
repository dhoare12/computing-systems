using ComputingSystems.Core;

namespace ComputingSystems.CombLogic.Interfaces
{
    public interface IMultiplexor
    {
        IPin Input1 { get; }
        IPin Input2 { get; }
        IPin Selector { get; }
        IPin Output { get; }

        void Fill(IPin input1, IPin input2, IPin selector);
    }
}