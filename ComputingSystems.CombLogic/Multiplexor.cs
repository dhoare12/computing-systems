namespace ComputingSystems.CombLogic
{
    public class Multiplexor : ThreeInputGate, ISingleOutputGate
    {
        private readonly And _and1 = new And(), _and2 = new And(), _and3 = new And(), _and4 = new And(), _and5 = new And();
        private readonly Not _not1 = new Not(), _not2 = new Not(), _not3 = new Not();
        private readonly Or _or1 = new Or(), _or2 = new Or();

        public bool Output
        {
            get
            {
                _and1.Fill(Input1, Input2);

                _not1.Fill(Input2);
                _not2.Fill(Input3);
                _and2.Fill(Input1, _not1.Output);
                _and3.Fill(_and2.Output, _not2.Output);

                _not3.Fill(Input1);
                _and4.Fill(_not3.Output, Input2);
                _and5.Fill(_and4.Output, Input3);

                _or1.Fill(_and1.Output, _and3.Output);
                _or2.Fill(_or1.Output, _and5.Output);
                return _or2.Output;
            }
        }
    }
}