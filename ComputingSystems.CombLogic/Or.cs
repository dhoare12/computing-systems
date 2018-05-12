using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;

namespace ComputingSystems.CombLogic
{
    public class Or : IOr
    {
        private readonly INot _not1 = TypeProvider.Get<INot>();
        private readonly INot _not2 = TypeProvider.Get<INot>();
        private readonly INand _nand = TypeProvider.Get<INand>();

        public bool Input1 { get; set; }
        public bool Input2 { get; set; }

        public bool Output
        {
            get
            {
                _not1.Input = Input1;
                _not2.Input = Input2;
                _nand.Fill(_not1.Output, _not2.Output);
                return _nand.Output;
            }
        }

        public void Fill(bool input1, bool input2)
        {
            Input1 = input1;
            Input2 = input2;
        }
    }
}