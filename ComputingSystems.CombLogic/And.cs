namespace ComputingSystems.CombLogic
{
    public class And : TwoInputGate, ISingleOutputGate
    {
        private readonly Nand _nand = new Nand();
        private readonly Not _not = new Not();

        public bool Output
        {
            get
            {
                _nand.Fill(Input1, Input2);
                _not.Fill(_nand.Output);
                return _not.Output;
            }
        }

        public override string ToString() => Output ? "1" : "0";
    }
}