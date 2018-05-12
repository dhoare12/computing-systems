using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;

namespace ComputingSystems.CombLogic
{
    public class Not : INot
    {
        private readonly INand _nand = TypeProvider.Get<INand>();

        public bool Input { get; set; }

        public bool Output
        {
            get
            {
                _nand.Input1 = Input;
                _nand.Input2 = Input;
                return _nand.Output;
            }
        }
    }
}