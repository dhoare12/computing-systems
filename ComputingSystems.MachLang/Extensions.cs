using System.Linq;

namespace ComputingSystems.MachLang
{
    public static class BoolArrayExtensions
    {
        public static string ToStringRepresentation(this bool[] bits)
        {
            return new string(bits.Select(x => x ? '1' : '0').ToArray());
        }
    }

    public static class StringExtensions
    {
        public static bool[] ToBits(this string str)
        {
            return str
                .Select(c => c == '1')
                .ToArray();
        }
    }
}