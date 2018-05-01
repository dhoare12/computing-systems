using ComputingSystems.CombLogic;
using ComputingSystems.CombLogic.ReferenceImplementations;

namespace ComputingSystems.BoolArith
{
    public class HalfAdder : TwoInputGate, ITwoOutputGate
    {
        private readonly And _and1 = new And(), _and2 = new And(), _and3 = new And();
        private readonly Or _or = new Or();
        private readonly Not _not1 = new Not(), _not2 = new Not();

        public bool Output1
        {
            get
            {
                _not1.Fill(Input1);
                _not2.Fill(Input2);
                _and1.Fill(Input1, _not2.Output);
                _and2.Fill(Input2, _not1.Output);
                _or.Fill(_and1.Output, _and2.Output);
                return _or.Output;
            }
        }

        public bool Output2
        {
            get
            {
                _and3.Fill(Input1, Input2);
                return _and3.Output;
            }
        }
    }
}
