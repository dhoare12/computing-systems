namespace ComputingSystems.CombLogic.ReferenceImplementations
{
    public class Multiplexor : ThreeInputGate, ISingleOutputGate
    {
        // Input3 = control
        public bool Output => Input3 ? Input2 : Input1;
    }
}