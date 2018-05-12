namespace ComputingSystems.CombLogic.ReferenceImplementations
{
    public class Xor : TwoInputGate, ISingleOutputGate
    {
        public bool Output => Input1 != Input2;
    }
}
