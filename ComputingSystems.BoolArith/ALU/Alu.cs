using ComputingSystems.CombLogic.ReferenceImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputingSystems.BoolArith.ALU
{
    public class Alu
    {
        private readonly InputTransformChip _xTransform = new InputTransformChip(),
            _yTransform = new InputTransformChip();

        private readonly SixteenBitAdder _adder = new SixteenBitAdder();
        private readonly SixteenBitAnder _ander = new SixteenBitAnder();

        private readonly And[] _ands = Enumerable.Range(0, 16).Select(_ => new And()).ToArray();
        private readonly SixteenBitNegator _negator = new SixteenBitNegator();
        private readonly SixteenBitNegator _negator2 = new SixteenBitNegator();

        private readonly SixteenBitMux _mux1 = new SixteenBitMux();
        private readonly SixteenBitMux _mux2 = new SixteenBitMux();

        private bool Zx { get; set; }
        private bool Nx { get; set; }
        private bool Zy { get; set; }
        private bool Ny { get; set; }
        private bool F { get; set; }
        private bool No { get; set; }
        private bool[] X { get; set; }
        private bool[] Y { get; set; }

        public void Fill(bool zx, bool nx, bool zy, bool ny, bool f, bool no, bool[] x, bool[] y)
        {
            Zx = zx;
            Nx = nx;
            Zy = zy;
            Ny = ny;
            F = f;
            No = no;
            X = x;
            Y = y;
        }

        public bool[] Out
        {
            get
            {
                _xTransform.Fill(Zx, Nx, X);
                _yTransform.Fill(Zy, Ny, Y);

                _adder.Fill(_xTransform.Output, _yTransform.Output);
                _ander.Fill(_xTransform.Output, _yTransform.Output);
                _mux1.Fill(_adder.Outputs, _ander.Output, F);

                _negator.Fill(_mux1.Output);
                _mux2.Fill(_mux1.Output, _negator.Output, No);

                return _mux2.Output;
            }
        }

        public bool Zr
        {
            get
            {
                _negator2.Fill(Out);
                var output = _negator2.Output;
                _ands[0].Fill(output[0], output[1]);
                for (var i = 1; i < 15; i++)
                {
                    _ands[i].Fill(_ands[i - 1].Output, output[i + 1]);
                }
                return _ands[15].Output;
            }
        }

        public bool Ng
        {
            get
            {
                return Out[0];
            }
        }
    }
}