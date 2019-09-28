using System;
using System.Linq;

namespace ComputingSystems.BoolArith.Tests
{
    public class TwosComplementConverter
    {
        public bool[] SignedIntToBits(int input, int noBits)
        {
            if (input <= 0)
            {
                var positiveValue = -input;
                var bits = UnsignedIntToBits(positiveValue, noBits);

                var foundTrue = false;

                for (var i = 0; i < bits.Length; i++)
                {
                    if (!foundTrue && bits[i])
                    {
                        foundTrue = true;
                        continue;
                    }

                    if (foundTrue)
                    {
                        bits[i] = !bits[i];
                    }
                }

                return bits;
            }

            return UnsignedIntToBits(input, noBits);
        }

        public bool[] UnsignedIntToBits(int input, int noBits)
        {
            var powers = Enumerable
                .Range(0, noBits)
                .Select(x => (int) Math.Pow(2, x))
                .ToArray();

            var value = input;

            var bits = new bool[noBits];

            for (var i = powers.Length - 1; i >= 0; i--)
            {
                if (value >= powers[i])
                {
                    bits[i] = true;
                    value -= powers[i];
                }
            }

            return bits;
        }

        public int BitsToSignedInt(bool[] input)
        {
            var unsigned = BitsToUnsignedInt(input);
            var signedCutOff = Math.Pow(2, input.Length - 1) - 1;
            if (unsigned <= signedCutOff)
            {
                return unsigned;
            }
            else
            {
                return unsigned - (int)Math.Pow(2, input.Length);
            }
        }

        public int BitsToUnsignedInt(bool[] input)
        {
            return (int)input
                .Select((x, i) => x ? Math.Pow(2, i) : 0)
                .Aggregate((x, y) => x + y);
        }
    }
}
