using System.Linq;
using ComputingSystems.Core;

namespace ComputingSystems.BoolArith
{
    public class SixteenBitAdder
    {
        private readonly FullAdder[] _adders = Enumerable.Range(0, 16).Select(_ => new FullAdder()).ToArray();

        public SixteenBitAdder()
        {
            for (var i = 0; i < 16; i++)
            {
                var carriedBit = i == 0 ? new ValuePin(() => false) : _adders[i - 1].Carry;

                _adders[i].Fill(carriedBit, Input1[i], Input2[i]);
            }
        }

        public void Fill(IPin[] input1, IPin[] input2)
        {
            for (var i = 0; i < 16; i++)
            {
                Input1[i].AttachInput(input1[i]);
                Input2[i].AttachInput(input2[i]);
            }
        }

        public IPin[] Outputs
        {
            get
            {
                return _adders.Select(a => a.Output).ToArray();
            }
        }

        public IPin[] Input1 { get; }= Enumerable.Range(0, 16).Select(_ => new Pin()).ToArray();
        public IPin[] Input2 { get; }= Enumerable.Range(0, 16).Select(_ => new Pin()).ToArray();
    }
}