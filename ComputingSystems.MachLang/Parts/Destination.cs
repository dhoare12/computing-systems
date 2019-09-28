using System;

namespace ComputingSystems.MachLang.Parts
{
    [Flags]
    public enum Destination
    {
        None = 0,
        M = 1,
        D = 2,
        A = 4
    }

    public static class DestinationMnemonicParser
    {
        public static Destination MnemonicToDestination(string mnemonic)
        {
            if (mnemonic == null)
            {
                return Destination.None;
            }

            var val = Destination.None;
            if (mnemonic.Contains("M"))
            {
                val |= Destination.M;
            }

            if (mnemonic.Contains("D"))
            {
                val |= Destination.D;
            }

            if (mnemonic.Contains("A"))
            {
                val |= Destination.A;
            }

            return val;
        }

        public static string DestinationToMnemonic(Destination destination)
        {
            var val = string.Empty;
            if ((destination & Destination.A) == Destination.A)
            {
                val += "A";
            }

            if ((destination & Destination.M) == Destination.M)
            {
                val += "M";
            }

            if ((destination & Destination.D) == Destination.D)
            {
                val += "D";
            }

            return val == string.Empty ? null : val;
        }
    }

    public static class DestinationBitParser
    {
        public static bool[] DestinationToBits(Destination dest)
        {
            return new[]
            {
                (dest & Destination.A) == Destination.A,
                (dest & Destination.D) == Destination.D,
                (dest & Destination.M) == Destination.M
            };
        }

        public static Destination BitsToDestination(bool[] bits)
        {
            var dest = Destination.None;

            if (bits[0])
            {
                dest |= Destination.A;
            }

            if (bits[1])
            {
                dest |= Destination.D;
            }

            if (bits[2])
            {
                dest |= Destination.M;
            }

            return dest;
        }
    }
}