using System;
using System.Linq;

namespace ComputingSystems.BoolArith.ReferenceImplementation
{
    public class TwosComplementConverter
    {
        public bool[] SignedIntToBits(int input, int noBits)
        {
            var bits = Enumerable.Range(0, noBits).Select(_ => false).ToArray();
            var max = Math.Pow(2, noBits - 1) - 1;
            var min = -Math.Pow(2, noBits - 1);
            if (input > max || input < min)
            {
                throw new Exception("Overflow");
            }
            var powers = Enumerable.Range(0, noBits).Select(x => (int)Math.Pow(2, noBits - x - 1)).ToArray();

            var absInput = Math.Abs(input);
            var absOutput = UnsignedIntToBits(input, noBits);
            if (input >= 0)
            {
                return UnsignedIntToBits(input, noBits);
            } else
            {
                return UnsignedIntToBits((int)Math.Pow(2, noBits) + input, noBits);
            }
        }

        public bool[] UnsignedIntToBits(int input, int noBits)
        {
            var bits = Enumerable.Range(0, noBits).Select(_ => false).ToArray();
            var powers = Enumerable.Range(0, noBits).Select(x => (int)Math.Pow(2, noBits - x - 1)).ToArray();
            for (var x = 0; x < noBits; x++)
            {
                if (input >= powers[x])
                {
                    bits[x] = true;
                    input -= powers[x];
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
            var value = 0;
            var integral = 0;
            for (var i = input.Length - 1; i >=0; i--)
            {
                var multiplier = Math.Pow(2, integral);
                value += (int)multiplier * (input[i] ? 1 : 0);
                integral++;
            }
            return value;
        }
    }
}
