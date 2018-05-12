using System.Linq;
using ComputingSystems.CombLogic.ReferenceImplementations;

namespace ComputingSystems.BoolArith
{
    public class SixteenBitNegator
    {
        private bool[] _input;

        private readonly Not[] _not = Enumerable.Range(0, 16).Select(_ => new Not()).ToArray();

        public void Fill(bool[] input)
        {
            _input = input;
        }

        public bool[] Output
        {
            get
            {
                for (var i = 0; i < 16; i++)
                {
                    _not[i].Fill(_input[i]);
                }

                return _not.Select(n => n.Output).ToArray();
            }
        }
    }
}
