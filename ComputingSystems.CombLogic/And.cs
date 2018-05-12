using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;

namespace ComputingSystems.CombLogic
{
    public class And : IAnd
    {
        private readonly INand _nand = TypeProvider.Get<INand>();
        private readonly INot _not = TypeProvider.Get<INot>();

        public bool Input1 { get; set; }
        public bool Input2 { get; set; }

        public bool Output
        {
            get
            {
                _nand.Fill(Input1, Input2);
                _not.Input = _nand.Output;
                return _not.Output;
            }
        }

        public void Fill(bool input1, bool input2)
        {
            Input1 = input1;
            Input2 = input2;
        }

        public override string ToString() => Output ? "1" : "0";
    }
}