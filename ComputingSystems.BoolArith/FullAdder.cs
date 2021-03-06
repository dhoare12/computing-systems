﻿using ComputingSystems.CombLogic;
using ComputingSystems.CombLogic.ReferenceImplementations;
using ComputingSystems.Core;

namespace ComputingSystems.BoolArith
{
    public class FullAdder
    {
        public FullAdder()
        {
            _not1.Input.AttachInput(Input1);
            _not2.Input.AttachInput(Input2);
            _not3.Input.AttachInput(Input3);

            _and1.Fill(Input1, _not2.Output);
            _and2.Fill(_and1.Output, _not3.Output);

            _and3.Fill(_not1.Output, Input2);
            _and4.Fill(_and3.Output, _not3.Output);

            _and5.Fill(_not1.Output, _not2.Output);
            _and6.Fill(_and5.Output, Input3);

            _and7.Fill(Input1, Input2);
            _and8.Fill(_and7.Output, Input3);

            _or1.Fill(_and2.Output, _and4.Output);
            _or2.Fill(_or1.Output, _and6.Output);
            _or3.Fill(_or2.Output, _and8.Output);

            _and9.Fill(Input1, Input2);
            _and10.Fill(Input1, Input3);
            _and11.Fill(Input2, Input3);
            _or4.Fill(_and9.Output, _and10.Output);
            _or5.Fill(_or4.Output, _and11.Output);
        }

        private readonly And _and1 = new And(), _and2 = new And(),_and3 = new And(),_and4 = new And(), _and5 = new And(), _and6 = new And(),
            _and7 = new And(), _and8 = new And();
        private readonly Or _or1 = new Or(), _or2 = new Or(), _or3 = new Or();
        private readonly Not _not1 = new Not(), _not2 = new Not(), _not3 = new Not();

        private readonly And _and9 = new And(), _and10 = new And(), _and11 = new And();
        private readonly Or _or4 = new Or(), _or5 = new Or();

        public IPin Input1 { get; } = new Pin();
        public IPin Input2 { get; } = new Pin();
        public IPin Input3 { get; } = new Pin();

        public void Fill(IPin input1, IPin input2, IPin input3)
        {
            Input1.AttachInput(input1);
            Input2.AttachInput(input2);
            Input3.AttachInput(input3);
        }

        // Value bit
        public IPin Output => _or3.Output;

        // Carry bit
        public IPin Carry => _or5.Output;
    }
}
