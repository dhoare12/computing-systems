namespace ComputingSystems.CombLogic.ReferenceImplementations
{
    public class Or : TwoInputGate, ISingleOutputGate
    {
        public bool Output => !(!Input1 && !Input2);
    }
}
