namespace ComputingSystems.CombLogic
{
    public class Demultiplexor : TwoInputGate, ITwoOutputGate
    {
        private readonly And _and1 = new And(), _and2 = new And();
        private readonly Not _not = new Not();

        public bool Output1
        {
            get
            {
                _not.Fill(Input2);
                _and1.Fill(Input1, _not.Output);
                return _and1.Output;
            }
        }

        public bool Output2
        {
            get
            {
                _and2.Fill(Input1, Input2);
                return _and2.Output;
            }
        }
    }
}