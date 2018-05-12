using ComputingSystems.CombLogic.Interfaces;

namespace ComputingSystems.CombLogic.ReferenceImplementations
{
    public class Xor : IXor
    {
        public bool Input1 { get; set; }
        public bool Input2 { get; set; }
        public bool Output => Input1 != Input2;
    }
}