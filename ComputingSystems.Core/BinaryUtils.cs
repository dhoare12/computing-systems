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
    }
}