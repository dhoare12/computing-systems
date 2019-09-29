using System.Linq;
using ComputingSystems.Core;
using ComputingSystems.MachLang.Parts;

namespace ComputingSystems.MachLang
{
    public class Interpreter
    {
        public string Interpret(bool[] bits)
        {
            return bits[0] ? InterpretCInstruction(bits) : InterpretAInstruction(bits);
        }

        private static string InterpretCInstruction(bool[] bits)
        {
            var comp = ComputationBitParser.BitsToComputation(bits.Skip(4).Take(6).ToArray(), bits[3]);
            var dest = DestinationBitParser.BitsToDestination(bits.Skip(10).Take(3).ToArray());
            var jump = JumpBitParser.BitsToJump(bits.Skip(13).Take(3).ToArray());

            var compString = ComputationMnemonicParser.ComputationToMnemonic(comp);
            var destString = DestinationMnemonicParser.DestinationToMnemonic(dest);
            var jumpString = JumpMnemonicParser.JumpToMnemonic(jump);

            var mnemonic = string.Empty;
            if (destString != null)
            {
                mnemonic += destString + "=";
            }

            mnemonic += compString;

            if (jumpString != null)
            {
                mnemonic += ";" + jumpString;
            }

            return mnemonic;
        }

        private static string InterpretAInstruction(bool[] bits)
        {
            return $"@{BinaryUtils.BitsToInt(bits.Skip(1).ToArray(), 15)}";
        }
    }
}