using System;
using System.Linq;

namespace ComputingSystems.Core
{
    public static class BinaryUtils
    {
        public static bool[] EmptyArray(int length)
        {
            return Enumerable.Range(0, length).Select(_ => false).ToArray();
        }

        public static bool[][] EmptyArray(int lengthA, int lengthB)
        {
            return Enumerable.Range(0, lengthA).Select(_ => EmptyArray(lengthB)).ToArray();
        }

        public static bool[] IntToBits(int number, int noBits)
        {
            var powers = Enumerable.Range(1, noBits).Select(p => (int)Math.Pow(2, noBits - p)).ToArray();
            var bits = EmptyArray(noBits);
            for (var i = 0; i < powers.Length; i++)
            {
                if (number >= powers[i])
                {
                    number -= powers[i];
                    bits[i] = true;
                }
            }

            return bits;
        }

        public static int BitsToInt(bool[] bits, int noBits)
        {
            var powers = Enumerable.Range(0, noBits).Select(p => (int)Math.Pow(2, noBits - p - 1)).ToArray();
            return powers.Where((t, i) => bits[i]).Sum();
        }

        public static bool[] SixteenBitIntToBits(int number)
        {
            return IntToBits(number, 16);
        }

        public static int SixteenBitBitsToInt(bool[] bits)
        {
            return BitsToInt(bits, 16);
        }
    }
}