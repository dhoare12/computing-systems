namespace ComputingSystems.CombLogic
{
    public class Nand : TwoInputGate, ISingleOutputGate
    {
        public bool Output => !(Input1 && Input2);
    }
}