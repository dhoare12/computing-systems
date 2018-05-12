using ComputingSystems.CombLogic.Interfaces;

namespace ComputingSystems.CombLogic.ReferenceImplementations
{
    public class And : IAnd
    {
        public bool Input1 { get; set; }
        public bool Input2 { get; set; }
        public bool Output => Input1 && Input2;

        public void Fill(bool input1, bool input2)
        {
            Input1 = input1;
            Input2 = input2;
        }

        public override string ToString() => Output ? "1" : "0";
    }
}