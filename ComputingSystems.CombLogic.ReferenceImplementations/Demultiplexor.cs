namespace ComputingSystems.CombLogic.ReferenceImplementations
{
    public class Demultiplexor : TwoInputGate, ITwoOutputGate
    {
        public bool Output1 => !Input2 && Input1;
        public bool Output2 => Input2 && Input1;
    }
}