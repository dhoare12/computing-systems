using ComputingSystems.Core;

namespace ComputingSystems.CombLogic.Interfaces
{
    public interface IDemultiplexor
    {
        IPin Input { get;  }
        IPin Selector { get; }
        IPin Output1 { get; }
        IPin Output2 { get; }

        void Fill(IPin input, IPin selector);
    }
}