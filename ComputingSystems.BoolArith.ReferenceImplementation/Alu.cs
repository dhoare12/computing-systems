using System.Linq;

namespace ComputingSystems.BoolArith.ReferenceImplementation
{
    public class Alu
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

        public bool[] Out { get
            {
                var x = _converter.BitsToUnsignedInt(X);
                var y = _converter.BitsToUnsignedInt(Y);
                if (Zx)
                {
                    x = 0;
                }
                if (Nx)
                {
                    x = -x;
                }
                if (Zy)
                {
                    y = 0;
                }
                if (Ny)
                {
                    y = -y;
                }
                var output = F ? x + y : And(x,y, X.Length); // TODO: & is not correct
                if (No)
                {
                    output = -output;
                }
                return _converter.SignedIntToBits(output, X.Length);
            }
        }

        private int And(int a, int b, int noBits)
        {
            var aBits = _converter.SignedIntToBits(a, noBits);
            var bBits = _converter.SignedIntToBits(b, noBits);
            var bits = Enumerable.Range(0, noBits).Select(_ => false).ToArray();
            for (var i = 0; i < noBits; i++)
            {
                bits[i] = aBits[i] && bBits[i];
            }

            return _converter.BitsToUnsignedInt(bits);
        }
    }
}