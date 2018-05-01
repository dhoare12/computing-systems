using System.Linq;
using ComputingSystems.CombLogic.ReferenceImplementations;

namespace ComputingSystems.BoolArith.ALU
{
    public class InputTransformChip
    {
        private bool _z;
        private bool _n;
        private bool[] _input;

        private readonly SixteenBitMux _mux1 = new SixteenBitMux();
        private readonly SixteenBitMux _mux2 = new SixteenBitMux();
        private readonly SixteenBitNegator _not = new SixteenBitNegator();
        private readonly bool[] _zero = Enumerable.Range(0, 16).Select(_ => false).ToArray();

        public void Fill(bool zero, bool negate, bool[] input)
        {
            _z = zero;
            _n = negate;
            _input = input;
        }

        public bool[] Output
        {
            get
            {
                _not.Fill(_input);
                _mux1.Fill(_input, _not.Output, _n);
                _mux2.Fill(_mux1.Output, _zero , _z);
                

                return _mux2.Output;
            }
        }
    }
}
