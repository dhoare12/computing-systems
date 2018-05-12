using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;

namespace ComputingSystems.CombLogic
{
    public class Multiplexor : IMultiplexor
    {
        private readonly IAnd[] _ands = TypeProvider.GetArray<IAnd>(5);
        private readonly INot[] _nots = TypeProvider.GetArray<INot>(3);
        private readonly IOr[] _ors = TypeProvider.GetArray<IOr>(2);

        public bool Input1 { get; set; }
        public bool Input2 { get; set; }
        public bool Selector { get; set; }

        public bool Output
        {
            get
            {
                _ands[0].Fill(Input1, Input2);

                _nots[0].Input = Input2;
                _nots[1].Input = Selector;
                _ands[1].Fill(Input1, _nots[0].Output);
                _ands[2].Fill(_ands[1].Output, _nots[1].Output);

                _nots[2].Input = Input1;
                _ands[3].Fill(_nots[2].Output, Input2);
                _ands[4].Fill(_ands[3].Output, Selector);

                _ors[0].Fill(_ands[0].Output, _ands[2].Output);
                _ors[1].Fill(_ors[0].Output, _ands[4].Output);
                return _ors[1].Output;
            }
        }

        public void Fill(bool input1, bool input2, bool selector)
        {
            Input1 = input1;
            Input2 = input2;
            Selector = selector;
        }
    }
}