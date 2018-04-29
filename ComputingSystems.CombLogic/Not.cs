namespace ComputingSystems.CombLogic
{
    public class Not : SingleInputGate, ISingleOutputGate
    {
        private readonly Nand _nand = new Nand();

        public bool Output
        {
            get
            {
                _nand.Fill(Input, Input);
                return _nand.Output;
            }
        }
    }
}