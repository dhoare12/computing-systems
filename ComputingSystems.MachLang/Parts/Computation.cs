using System.Collections.Generic;
using System.Linq;

namespace ComputingSystems.MachLang.Parts
{
    public enum Computation
    {
        Zero,
        One,
        MinusOne,
        D,
        A,
        NotD,
        NotA,
        MinusD,
        MinusA,
        DPlusOne,
        APlusOne,
        DMinusOne,
        AMinusOne,
        DPlusA,
        DMinusA,
        AMinusD,
        DAndA,
        DOrA,

        M,
        NotM,
        MinusM,
        MPlusOne,
        MMinusOne,
        DPlusM,
        DMinusM,
        MMinusD,
        DAndM,
        DOrM
    }

    public static class ComputationMnemonicParser
    {
        private static readonly Dictionary<Computation, string> Map = new Dictionary<Computation, string>
        {
            [Computation.Zero] = "0",
            [Computation.One] = "1",
            [Computation.MinusOne] = "-1",
            [Computation.D] = "D",
            [Computation.A] = "A",
            [Computation.NotD] = "!D",
            [Computation.NotA] = "!A",
            [Computation.MinusD] = "-D",
            [Computation.MinusA] = "-A",
            [Computation.DPlusOne] = "D+1",
            [Computation.APlusOne] = "A+1",
            [Computation.DMinusOne] = "D-1",
            [Computation.AMinusOne] = "A-1",
            [Computation.DPlusA] = "D+A",
            [Computation.DMinusA] = "D-A",
            [Computation.AMinusD] = "A-D",
            [Computation.DAndA] = "D&A",
            [Computation.DOrA] = "D|A",

            [Computation.M] = "M",
            [Computation.NotM] = "!M",
            [Computation.MinusM] = "-M",
            [Computation.MPlusOne] =  "M+1",
            [Computation.MMinusOne] = "M-1",
            [Computation.DPlusM] = "D+M",
            [Computation.DMinusM] = "D-M",
            [Computation.MMinusD] = "M-D",
            [Computation.DAndM] = "D&M",
            [Computation.DOrM] = "D|M"
        };

        public static Computation MnemonicToComputation(string mnemonic) => Map.Single(x => x.Value == mnemonic).Key;

        public static string ComputationToMnemonic(Computation computation) => Map[computation];
    }

    public static class ComputationBitParser
    {
        private static readonly List<(Computation, string)> NotAMap = new List<(Computation, string)>
        {
            (Computation.Zero, "101010"),
            (Computation.One, "111111"),
            (Computation.MinusOne, "111010"),
            (Computation.D, "001100"),
            (Computation.A, "110000"),
            (Computation.NotD, "001101"),
            (Computation.NotA, "110001"),
            (Computation.MinusD, "001111"),
            (Computation.MinusA, "110011"),
            (Computation.DPlusOne, "011111"),
            (Computation.APlusOne, "110111"),
            (Computation.DMinusOne, "001110"),
            (Computation.AMinusOne, "110010"),
            (Computation.DPlusA, "000010"),
            (Computation.DMinusA, "010011"),
            (Computation.AMinusD, "000111"),
            (Computation.DAndA, "000000"),
            (Computation.DOrA, "010101")
        };

        private static readonly List<(Computation, string)> AMap = new List<(Computation, string)>
        {
            (Computation.M, "110000"),
            (Computation.NotM, "110001"),
            (Computation.MinusM, "110011"),
            (Computation.MPlusOne, "110111"),
            (Computation.MMinusOne, "110010"),
            (Computation.DPlusM, "000010"),
            (Computation.DMinusM, "010011"),
            (Computation.MMinusD, "000111"),
            (Computation.DAndM, "000000"),
            (Computation.DOrM, "010101")
        };

        public static Computation BitsToComputation(bool[] c, bool a)
        {
            var cString = string.Join("", c.Select(x => x ? '1' : '0'));
            var map = a ? AMap : NotAMap;

            return map.Single(m => m.Item2 == cString).Item1;
        }

        public static (bool[], bool) ComputationToBits(Computation computation)
        {
            var aMatch = AMap.SingleOrDefault(x => x.Item1 == computation);

            if (aMatch != default)
            {
                return (aMatch.Item2.Select(x => x == '1').ToArray(), true);
            }

            var notAMatch = NotAMap.Single(x => x.Item1 == computation);
            return (notAMatch.Item2.Select(x => x == '1').ToArray(), true);
        }
    }
}