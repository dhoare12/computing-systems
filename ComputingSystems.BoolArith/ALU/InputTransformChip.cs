using System.Linq;
using ComputingSystems.Core;

namespace ComputingSystems.BoolArith.ALU
{
    public class InputTransformChip
    {
        public InputTransformChip()
        {
            _not.Fill(_mux1.Output);
        }

        private readonly SixteenBitMux _mux1 = new SixteenBitMux();
        private readonly SixteenBitMux _mux2 = new SixteenBitMux();
        private readonly SixteenBitNegator _not = new SixteenBitNegator();
        private readonly ValuePin[] _zeros = Enumerable.Range(0, 16).Select(_ => new ValuePin(() => false)).ToArray();

        public void Fill(IPin zero, IPin negate, IPin[] input)
        {
            _mux1.Fill(input, _zeros, zero);

            _mux2.Fill(_mux1.Output, _not.Output , negate);
        }

        public IPin[] Output => _mux2.Output;
    }
}
