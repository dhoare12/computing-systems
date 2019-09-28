using System;
using System.Linq;
using ComputingSystems.BoolArith.Interfaces;
using ComputingSystems.Core;

namespace ComputingSystems.BoolArith.ReferenceImplementation
{
    public class Alu : IAlu
    {
        private readonly TwosComplementConverter _converter = new TwosComplementConverter();
        public bool Zx { get; set; }
        public bool Nx { get; set; }
        public bool Zy { get; set; }
        public bool Ny { get; set; }
        public bool F { get; set; }
        public bool No { get; set; }
        public bool[] X { get; set; }
        public bool[] Y { get; set; }

        public bool[] Out
        {
            get
            {
                var x = X;
                var y = Y;
                if (Zx)
                {
                    x = BinaryUtils.EmptyArray(16);
                }
                if (Nx)
                {
                    x = Negate(x);
                }
                if (Zy)
                {
                    y = BinaryUtils.EmptyArray(16);
                }
                if (Ny)
                {
                    y = Negate(y);
                }
                var output = F ? Add(x, y) : And(x, y, X.Length);
                if (No)
                {
                    output = Negate(output);
                }

                return output;
            }
        }

        private bool[] Add(bool[] x, bool[] y)
        {
            return _converter.SignedIntToBits(_converter.BitsToSignedInt(x) + _converter.BitsToSignedInt(y), 16);
        }

        public void Fill(bool zx, bool nx, bool zy, bool ny, bool f, bool no, bool[] x, bool[] y)
        {
            Zx = zx;
            Nx = nx;
            Zy = zy;
            Ny = ny;
            F = f;
            No = no;
            X = x;
            Y = y;
        }

        private static bool[] And(bool[] a, bool[] b, int noBits)
        {
            return a.Select((x, i) => x && b[i]).ToArray();
        }

        private static bool[] Negate(bool[] bits)
        {
            return bits.Select(b => !b).ToArray();
        }

        public bool Ng => Out[0];
        public bool Zr => Out.All(x => x == false);
    }
}