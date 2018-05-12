using ComputingSystems.CombLogic.Interfaces;

namespace ComputingSystems.CombLogic.ReferenceImplementations
{
    public class Not : INot
    {
        public bool Input { get; set; }
        public bool Output => !Input;
    }
}