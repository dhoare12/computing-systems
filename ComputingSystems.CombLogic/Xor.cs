namespace ComputingSystems.CombLogic
{
    public class Xor : TwoInputGate, ISingleOutputGate
    {
        private readonly And _and1 = new And();
        private readonly And _and2 = new And();
        private readonly Not _not1 = new Not();
        private readonly Not _not2 = new Not();
        private readonly Or _or = new Or();
        public bool Output
        {
            get
            {
                _not1.Fill(Input1);
                _not2.Fill(Input2);
                _and1.Fill(Input1, _not2.Output);
                _and2.Fill(_not1.Output, Input2);
                _or.Fill(_and1.Output, _and2.Output);
                return _or.Output;
            }
        }
    }
}