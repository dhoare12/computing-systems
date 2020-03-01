using ComputingSystems.CombLogic;
using ComputingSystems.CombLogic.ReferenceImplementations;
using ComputingSystems.Core;

namespace ComputingSystems.BoolArith
{
    public class HalfAdder
    {
        private readonly And _and1 = new And(), _and2 = new And(), _and3 = new And();
        private readonly Or _or = new Or();
        private readonly Not _not1 = new Not(), _not2 = new Not();

        public IPin Input1 { get; } = new Pin();
        public IPin Input2 { get; } = new Pin();

        public void Fill(IPin in1, IPin in2)
        {
            Input1.AttachInput(in1);
            Input2.AttachInput(in2);
        }

        public IPin Output1
        {
            get
            {
                _and1.Fill(Input1, _not2.Output);
                _and2.Fill(Input2, _not1.Output);
                _or.Fill(_and1.Output, _and2.Output);
                return _or.Output;
            }
        }

        public IPin Output2
        {
            get
            {
                _and3.Fill(Input1, Input2);
                return _and3.Output;
            }
        }
    }
}
