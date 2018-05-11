using ComputingSystems.BoolArith.ReferenceImplementation;
using System;
using System.Linq;

namespace ComputingSystems.BoolArith.Tester
{
    class Program
    {
        static void Main(string[] args)

        {
            var c = new TwosComplementConverter();
            var tests = new[]
            {
                new[] { false }, // 0
                new[] { true }, // 1
                new[] { false, false }, // 0
                new[] { false, true }, // 1
                new[] { true, false }, // 2
                new[] { true, true }, // 3
                new[] { true, true, true }, // 7
                new[] { false, false, false } // 0

            };

            foreach (var test in tests)
            {
                Console.WriteLine(c.BitsToSignedInt(test));
            }

            while (true)
            {
                var input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(string.Join("", c.SignedIntToBits(input, 4).Select(x => x ? "1" : "0").ToArray()));

            }
        }
    }
}
