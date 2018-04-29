namespace ComputingSystems.CombLogic
{
    public class Or : TwoInputGate, ISingleOutputGate
    {
        private readonly Not _not1 = new Not();
        private readonly Not _not2 = new Not();
        private readonly Nand _nand = new Nand();

        public bool Output
        {
            get
            {
                _not1.Fill(Input1);
                _not2.Fill(Input2);
                _nand.Fill(_not1.Output, _not2.Output);
                return _nand.Output;
            }
        }
    }
}