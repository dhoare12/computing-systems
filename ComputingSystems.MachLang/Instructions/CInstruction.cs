using System.Linq;
using ComputingSystems.MachLang.Parts;

namespace ComputingSystems.MachLang.Instructions
{
    public class CInstruction : IInstruction
    {
        private readonly Destination _dest;
        private readonly Computation _comp;
        private readonly Jump _jump;

        public CInstruction(Destination dest, Computation comp, Jump jump)
        {
            _dest = dest;
            _comp = comp;
            _jump = jump;
        }

        public string Mnemonic => BuildMnemonic();
        public bool[] Bits => BuildBits();

        private string BuildMnemonic()
        {
            var mnemonic = "";
            if (_dest != Destination.None)
            {
                mnemonic += DestinationMnemonicParser.DestinationToMnemonic(_dest) + "=";
            }

            mnemonic += ComputationMnemonicParser.ComputationToMnemonic(_comp);

            if (_jump != Jump.NoJump)
            {
                mnemonic += ";" + JumpMnemonicParser.JumpToMnemonic(_jump);
            }

            return mnemonic;
        }

        private bool[] BuildBits()
        {
            var (compPart, aPart) = ComputationBitParser.ComputationToBits(_comp);
            var destPart = DestinationBitParser.DestinationToBits(_dest);
            var jumpPart = JumpBitParser.JumpToBits(_jump);

            return new[]
                {
                    true, true, true
                }.Concat(new[] { aPart })
                .Concat(compPart)
                .Concat(destPart)
                .Concat(jumpPart)
                .ToArray();
        }
    }
}