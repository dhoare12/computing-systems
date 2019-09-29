using System;
using System.Linq;
using ComputingSystems.BoolArith.Interfaces;
using ComputingSystems.Core;

namespace ComputingSystems.BoolArith.ReferenceImplementation
{
    public class Alu
    {
        private readonly TwosComplementConverter _converter = new TwosComplementConverter();

        public Alu()
        {
            Out = new ValueBus(16, x => CalculateValue()[x]);
            Ng = new ValuePin(() => CalculateValue()[0]);
            Zr = new ValuePin(() => CalculateValue().All(x => x == false));
        }

        public IPin Zx { get; set; }
        public IPin Nx { get; set; }
        public IPin Zy { get; set; }
        public IPin Ny { get; set; }
        public IPin F { get; set; }
        public IPin No { get; set; }
        public IBus X { get; set; }
        public IBus Y { get; set; }

        public IBus Out { get; }

        public void Fill(IPin zx, IPin nx, IPin zy, IPin ny, IPin f, IPin no, IBus x, IBus y)
        {
            Zx.AttachInput(zx);
            Nx.AttachInput(nx);
            Zy.AttachInput(zy);
            Ny.AttachInput(ny);
            F.AttachInput(f);
            No.AttachInput(no);
            X.AttachInput(x);
            Y.AttachInput(y);
        }

        private bool[] CalculateValue()
        {
            var x = X.Pins.Select(p => p.Value).ToArray();
            var y = Y.Pins.Select(p => p.Value).ToArray();
            if (Zx.Value)
            {
                x = BinaryUtils.EmptyArray(16);
            }
            if (Nx.Value)
            {
                x = Negate(x);
            }
            if (Zy.Value)
            {
                y = BinaryUtils.EmptyArray(16);
            }
            if (Ny.Value)
            {
                y = Negate(y);
            }
            var output = F.Value ? Add(x, y) : And(x, y);

            if (No.Value)
            {
                output = Negate(output);
            }

            return output;
        }

        private bool[] Add(bool[] x, bool[] y)
        {
            return _converter.SignedIntToBits(_converter.BitsToSignedInt(x) + _converter.BitsToSignedInt(y), 16);
        }

        private static bool[] And(bool[] a, bool[] b)
        {
            return a.Select((x, i) => x && b[i]).ToArray();
        }

        private static bool[] Negate(bool[] bits)
        {
            return bits.Select(b => !b).ToArray();
        }

        public IPin Ng { get; }
        public IPin Zr { get; }
    }
}