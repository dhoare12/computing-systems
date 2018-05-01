using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputingSystems.CombLogic.ReferenceImplementations;

namespace ComputingSystems.BoolArith
{
    public class SixteenBitAnder
    {
        private bool[] _x;
        private bool[] _y;

        private readonly And[] _and = Enumerable.Range(0, 16).Select(_ => new And()).ToArray();

        public void Fill(bool[] x, bool[] y)
        {
            _x = x;
            _y = y;
        }

        public bool[] Output
        {
            get
            {
                for (var i = 0; i < 16; i++)
                {
                    _and[i].Fill(_x[i], _y[i]);
                }

                return _and.Select(n => n.Output).ToArray();
            }
        }
    }
}
