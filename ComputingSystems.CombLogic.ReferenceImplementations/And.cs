namespace ComputingSystems.CombLogic.ReferenceImplementations
{
    public class And : TwoInputGate, ISingleOutputGate
    {
        public bool Output => Input1 && Input2;

        public override string ToString() => Output ? "1" : "0";
    }
}
