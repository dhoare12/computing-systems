using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;

namespace ComputingSystems.CombLogic
{
    public class Xor : IXor
    {
        private readonly IAnd _and1 = TypeProvider.Get<IAnd>();
        private readonly IAnd _and2 = TypeProvider.Get<IAnd>();
        private readonly INot _not1 = TypeProvider.Get<INot>();
        private readonly INot _not2 = TypeProvider.Get<INot>();
        private readonly IOr _or = TypeProvider.Get<IOr>();

        public bool Input1 { get; set; }
        public bool Input2 { get; set; }

        public bool Output
        {
            get
            {
                _not1.Input = Input1;
                _not2.Input = Input2;
                _and1.Fill(Input1, _not2.Output);
                _and2.Fill(_not1.Output, Input2);
                _or.Fill(_and1.Output, _and2.Output);
                return _or.Output;
            }
        }
    }
}