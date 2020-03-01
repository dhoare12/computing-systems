using System.Linq;
using ComputingSystems.CombLogic.ReferenceImplementations;
using ComputingSystems.Core;

namespace ComputingSystems.BoolArith
{
    public class SixteenBitNegator
    {
        private readonly Not[] _not = Enumerable.Range(0, 16).Select(_ => new Not()).ToArray();

        public void Fill(IPin[] input)
        {
            for (var i = 0; i < 16; i++)
            {
                _not[i].Input.AttachInput(input[i]);
            }
        }

        public IPin[] Output => _not.Select(n => n.Output).ToArray();
    }
}