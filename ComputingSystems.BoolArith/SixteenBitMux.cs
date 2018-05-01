using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputingSystems.CombLogic.ReferenceImplementations;

namespace ComputingSystems.BoolArith
{
    public class SixteenBitMux
    {
        private bool[] _x;
        private bool[] _y;
        private bool _control;

        private readonly Multiplexor[] _mux = Enumerable.Range(0, 16).Select(_ => new Multiplexor()).ToArray();

        public void Fill(bool[] x, bool[] y, bool control)
        {
            _x = x;
            _y = y;
            _control = control;
        }

        public bool[] Output
        {
            get
            {
                for (var i = 0; i < 16; i++)
                {
                    _mux[i].Fill(_x[i], _y[i], _control);
                }

                return _mux.Select(n => n.Output).ToArray();
            }
        }
    }
}
