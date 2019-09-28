using System.Collections.Generic;
using System.Linq;

namespace ComputingSystems.MachLang.Parts
{
    public enum Jump
    {
        NoJump,
        JumpIfGreaterThanZero,
        JumpIfZero,
        JumpIfGreaterThanOrEqualToZero,
        JumpIfLessThanZero,
        JumpIfNotZero,
        JumpIfLessThanOrEqualToZero,
        Jump
    }

    public static class JumpMnemonicParser
    {
        private static readonly Dictionary<Jump, string> Map = new Dictionary<Jump, string>
        {
            [Jump.NoJump] = null,
            [Jump.JumpIfGreaterThanZero] = "JGT",
            [Jump.JumpIfZero] = "JEQ",
            [Jump.JumpIfGreaterThanOrEqualToZero] = "JGE",
            [Jump.JumpIfLessThanZero] = "JLT",
            [Jump.JumpIfNotZero] = "JNE",
            [Jump.JumpIfLessThanOrEqualToZero] = "JLE",
            [Jump.Jump] = "JMP",
        };

        public static string JumpToMnemonic(Jump jump) => Map[jump];

        public static Jump MnemonicToJump(string mnemonic) => Map.Single(x => x.Value == mnemonic).Key;
    }

    public static class JumpBitParser
    {
        private static readonly Dictionary<Jump, string> Map = new Dictionary<Jump, string>
        {
            [Jump.NoJump] = "000",
            [Jump.JumpIfGreaterThanZero] = "001",
            [Jump.JumpIfZero] = "010",
            [Jump.JumpIfGreaterThanOrEqualToZero] = "011",
            [Jump.JumpIfLessThanZero] = "100",
            [Jump.JumpIfNotZero] = "101",
            [Jump.JumpIfLessThanOrEqualToZero] = "110",
            [Jump.Jump] = "111",
        };

        public static bool[] JumpToBits(Jump jump) => Map[jump].ToBits();

        public static Jump BitsToJump(bool[] bits) => Map.Single(x => x.Value == bits.ToStringRepresentation()).Key;
    }
}