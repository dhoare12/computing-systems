using System.Linq;

namespace ComputingSystems.SeqLogic
{
    public static class StringExtensions
    {
        public static bool[] ToBinary(this string input)
        {
            return input.ToCharArray().Where(i => i == '1' || i == '0').Select(i => i == '1').ToArray();
        }
    }

    public static class BoolArrayExtensions
    {
        public static string ToBinaryString(this bool[] input)
        {
            return string.Join("", input.Select(i => i ? "1" : "0").ToArray());
        }
    }
}
