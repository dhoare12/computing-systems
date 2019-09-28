using System;
using System.Text.RegularExpressions;
using ComputingSystems.MachLang.Instructions;
using ComputingSystems.MachLang.Parts;

namespace ComputingSystems.MachLang
{
    public class InstructionParser
    {
        private static readonly Regex AInstruction = new Regex(@"@(?<value>[a-zA-Z]+|[0-9]+)");
        private static readonly Regex CInstruction = new Regex(@"((?<dest>[AMD]{1,3})=)?(?<comp>[AMD01\-\+!|\&]{1,3})(;(?<jump>[A-Z]{3}))?");

        public IInstruction Parse(string mnemonic)
        {
            var match = AInstruction.Match(mnemonic);
            if (match.Success)
            {
                if (int.TryParse(match.Groups["value"].Value, out var literal))
                {
                    return new ALiteralInstruction(literal);
                }

                return new ASymbolInstruction(match.Groups["value"].Value);
            }

            match = CInstruction.Match(mnemonic);

            if (!match.Success)
            {
                throw new Exception("Failed to parse instruction");
            }

            var destString = match.Groups["dest"].Value;
            var dest = DestinationMnemonicParser.MnemonicToDestination(destString == string.Empty ? null : destString);

            var comp = ComputationMnemonicParser.MnemonicToComputation(match.Groups["comp"].Value);

            var jumpString = match.Groups["jump"].Value;
            var jump = JumpMnemonicParser.MnemonicToJump(jumpString == string.Empty ? null : jumpString);

            return new CInstruction(dest, comp, jump);
        }

    }
}
