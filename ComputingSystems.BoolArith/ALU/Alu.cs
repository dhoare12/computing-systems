using ComputingSystems.CombLogic.ReferenceImplementations;
using System.Linq;
using ComputingSystems.BoolArith.Interfaces;
using ComputingSystems.Core;

namespace ComputingSystems.BoolArith.ALU
{
    public class Alu
    {
        public Alu()
        {
            _negator2.Fill(Out);
            var output = _negator2.Output;

            _ands[0].Fill(output[0], output[1]);

            _ander.Fill(_xTransform.Output, _yTransform.Output);
            _adder.Fill(_xTransform.Output, _yTransform.Output);
            _negator.Fill(_mux1.Output);

            for (var i = 1; i < 15; i++)
            {
                _ands[i].Fill(_ands[i - 1].Output, output[i + 1]);
            }
        }

        private readonly InputTransformChip _xTransform = new InputTransformChip(),
            _yTransform = new InputTransformChip();

        private readonly SixteenBitAdder _adder = new SixteenBitAdder();
        private readonly SixteenBitAnder _ander = new SixteenBitAnder();

        private readonly And[] _ands = Enumerable.Range(0, 15).Select(_ => new And()).ToArray();
        private readonly SixteenBitNegator _negator = new SixteenBitNegator();
        private readonly SixteenBitNegator _negator2 = new SixteenBitNegator();

        private readonly SixteenBitMux _mux1 = new SixteenBitMux();
        private readonly SixteenBitMux _mux2 = new SixteenBitMux();

        /*public IPin Zx { get; set; }
        public IPin Nx { get; set; }
        public IPin Zy { get; set; }
        public IPin Ny { get; set; }
        public IPin F { get; set; }
        public IPin No { get; set; }
        public IPin[] X { get; set; }
        public IPin[] Y { get; set; }*/

        public void Fill(IPin zx, IPin nx, IPin zy, IPin ny, IPin f, IPin no, IPin[] x, IPin[] y)
        {
            _xTransform.Fill(zx, nx, x);
            _yTransform.Fill(zy, ny, y);
            _mux1.Fill(_ander.Output, _adder.Outputs, f);
            _mux2.Fill(_mux1.Output, _negator.Output, no);
        }

        public IPin[] Out => _mux2.Output;

        public IPin Zr => _ands[14].Output;

        public IPin Ng => Out[15];
    }
}