using ComputingSystems.CombLogic.Interfaces;

namespace ComputingSystems.CombLogic.ReferenceImplementations
{
    public class Demultiplexor : IDemultiplexor
    {
        public bool Input { get; set; }
        public bool Selector { get; set; }

        public bool Output1 => !Selector && Input;
        public bool Output2 => Selector && Input;

        public void Fill(bool input, bool selector)
        {
            Input = input;
            Selector = selector;
        }
    }
}