using System.Linq;

namespace ComputingSystems.BoolArith
{
    public class SixteenBitAdder
    {
        private readonly FullAdder[] _adders = Enumerable.Range(0, 16).Select(_ => new FullAdder()).ToArray();

        public void Fill(bool[] input1, bool[] input2)
        {
            Input1 = input1;
        }
        public bool[] Outputs
        {
            get
            {
                for (var i = 0; i < 16; i++)
                {
                    _adders[i].Fill(i == 0 ? false : _adders[i - 1].Output2, Input1[0], Input2[0]);
                }

                return _adders.Select(a => a.Output1).ToArray();
            }
        }

        public bool[] Input1 { get; private set; }
        public bool[] Input2 { get; private set; }
    }
}