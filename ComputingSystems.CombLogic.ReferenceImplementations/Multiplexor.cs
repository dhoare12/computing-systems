using ComputingSystems.CombLogic.Interfaces;

namespace ComputingSystems.CombLogic.ReferenceImplementations
{
    public class Multiplexor : IMultiplexor
    {
        public bool Input1 { get; set; }
        public bool Input2 { get; set; }
        public bool Selector { get; set; }
        public bool Output => Selector ? Input2 : Input1;

        public void Fill(bool input1, bool input2, bool selector)
        {
            Input1 = input1;
            Input2 = input2;
            Selector = selector;
        }
    }

    public class SixteenBitMultiplexor
    {
        public bool[] Input1 { get; set; }
        public bool[] Input2 { get; set; }
        public bool Selector { get; set; }
        public bool[] Output => Selector ? Input2 : Input1;

        public void Fill(bool[] input1, bool[] input2, bool selector)
        {
            Input1 = input1;
            Input2 = input2;
            Selector = selector;
        }
    }
}