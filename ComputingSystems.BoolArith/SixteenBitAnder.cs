using System.Linq;
using ComputingSystems.CombLogic.ReferenceImplementations;
using ComputingSystems.Core;

namespace ComputingSystems.BoolArith
{
    public class SixteenBitAnder
    {
        private bool[] _x;
        private bool[] _y;

        private readonly And[] _and = Enumerable.Range(0, 16).Select(_ => new And()).ToArray();

        public void Fill(IPin[] x, IPin[] y)
        {
            for (var i = 0; i < 16; i++)
            {
                _and[i].Fill(x[i], y[i]);
            }
        }

        public IPin[] Output => _and.Select(n => n.Output).ToArray();
    }
}
