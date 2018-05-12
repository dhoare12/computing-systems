using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;

namespace ComputingSystems.CombLogic
{
    public class Demultiplexor : IDemultiplexor
    {
        private readonly IAnd _and1 = TypeProvider.Get<IAnd>(), _and2 = TypeProvider.Get<IAnd>();
        private readonly Not _not = new Not();

        public bool Input { get; set; }
        public bool Selector { get; set; }

        public bool Output1
        {
            get
            {
                _not.Input = Selector;
                _and1.Fill(Input, _not.Output);
                return _and1.Output;
            }
        }

        public bool Output2
        {
            get
            {
                _and2.Fill(Input, Selector);
                return _and2.Output;
            }
        }

        public void Fill(bool input, bool selector)
        {
            Input = input;
            Selector = selector;
        }
    }
}