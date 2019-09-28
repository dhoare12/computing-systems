﻿using ComputingSystems.CombLogic.ReferenceImplementations;
using System.Linq;
using ComputingSystems.BoolArith.Interfaces;

namespace ComputingSystems.BoolArith.ALU
{
    public class Alu : IAlu
    {
        private readonly InputTransformChip _xTransform = new InputTransformChip(),
            _yTransform = new InputTransformChip();

        private readonly SixteenBitAdder _adder = new SixteenBitAdder();
        private readonly SixteenBitAnder _ander = new SixteenBitAnder();

        private readonly And[] _ands = Enumerable.Range(0, 15).Select(_ => new And()).ToArray();
        private readonly SixteenBitNegator _negator = new SixteenBitNegator();
        private readonly SixteenBitNegator _negator2 = new SixteenBitNegator();

        private readonly SixteenBitMux _mux1 = new SixteenBitMux();
        private readonly SixteenBitMux _mux2 = new SixteenBitMux();

        public bool Zx { get; set; }
        public bool Nx { get; set; }
        public bool Zy { get; set; }
        public bool Ny { get; set; }
        public bool F { get; set; }
        public bool No { get; set; }
        public bool[] X { get; set; }
        public bool[] Y { get; set; }

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

                _ander.Fill(_xTransform.Output, _yTransform.Output);
                _adder.Fill(_xTransform.Output, _yTransform.Output);

                _mux1.Fill(_ander.Output, _adder.Outputs, F);

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
                return _ands[14].Output;
            }
        }

        public bool Ng => Out[15];
    }
}