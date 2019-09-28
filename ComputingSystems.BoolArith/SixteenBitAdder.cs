using System.Linq;

namespace ComputingSystems.BoolArith
{
    public class SixteenBitAdder
    {
        private readonly FullAdder[] _adders = Enumerable.Range(0, 16).Select(_ => new FullAdder()).ToArray();

        public void Fill(bool[] input1, bool[] input2)
        {
            Input1 = input1;
            Input2 = input2;
        }
        public bool[] Outputs
        {
            get
            {
                for (var i = 0; i < 16; i++)
                {
                    var carriedBit = i != 0 && _adders[i - 1].Carry;

                    _adders[i].Fill(carriedBit, Input1[i], Input2[i]);
                }

                return _adders.Select(a => a.Output).ToArray();
            }
        }

        public bool[] Input1 { get; private set; }
        public bool[] Input2 { get; private set; }
    }
}