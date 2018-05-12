namespace ComputingSystems.CombLogic.ReferenceImplementations
{
    public class Not : SingleInputGate, ISingleOutputGate
    {
        public bool Output => !Input;
    }
}
