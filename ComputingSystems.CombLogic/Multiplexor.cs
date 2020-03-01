using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;

namespace ComputingSystems.CombLogic
{
    public class Multiplexor : IMultiplexor
    {
        private readonly IAnd[] _ands = TypeProvider.GetArray<IAnd>(5);
        private readonly INot[] _nots = TypeProvider.GetArray<INot>(3);
        private readonly IOr[] _ors = TypeProvider.GetArray<IOr>(2);

        public Multiplexor()
        {
            _ands[0].Fill(Input1, Input2);

            _nots[0].Input.AttachInput(Input2);
            _nots[1].Input.AttachInput(Selector);
            _ands[1].Fill(Input1, _nots[0].Output);
            _ands[2].Fill(_ands[1].Output, _nots[1].Output);

            _nots[2].Input.AttachInput(Input1);
            _ands[3].Fill(_nots[2].Output, Input2);
            _ands[4].Fill(_ands[3].Output, Selector);

            _ors[0].Fill(_ands[0].Output, _ands[2].Output);
            _ors[1].Fill(_ors[0].Output, _ands[4].Output);
        }

        public IPin Input1 { get; } = new Pin();
        public IPin Input2 { get; } = new Pin();
        public IPin Selector { get; } = new Pin();

        public IPin Output => _ors[1].Output;

        public void Fill(IPin input1, IPin input2, IPin selector)
        {
            Input1.AttachInput(input1);
            Input2.AttachInput(input2);
            Selector.AttachInput(selector);
        }
    }
}