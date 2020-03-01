using System.Linq;
using ComputingSystems.CombLogic.ReferenceImplementations;
using ComputingSystems.Core;

namespace ComputingSystems.BoolArith
{
    public class SixteenBitMux
    {
        private readonly Multiplexor[] _mux = Enumerable.Range(0, 16).Select(_ => new Multiplexor()).ToArray();

        public void Fill(IPin[] x, IPin[] y, IPin control)
        {
            for (var i = 0; i < 16; i++)
            {
                _mux[i].Fill(x[i], y[i], control);
            }
        }

        public IPin[] Output
        {
            get
            {
                return _mux.Select(n => n.Output).ToArray();
            }
        }
    }
}
