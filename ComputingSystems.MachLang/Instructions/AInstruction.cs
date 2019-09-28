using System;
using System.Linq;
using ComputingSystems.Core;

namespace ComputingSystems.MachLang.Instructions
{
    public abstract class AInstruction : IInstruction
    {
        public abstract string Mnemonic { get; }
        public abstract bool[] Bits { get; }
    }

    public class ALiteralInstruction : AInstruction
    {
        private readonly int _literal;
        public ALiteralInstruction(int literal)
        {
            _literal = literal;
        }

        public override string Mnemonic => $"@{_literal}";
        public override bool[] Bits => BinaryUtils.SixteenBitIntToBits(_literal); // TODO: Should be 0 + FifteenBit
    }

    public class ASymbolInstruction : AInstruction
    {
        public ASymbolInstruction(string symbol)
        {
            Symbol = symbol;
        }

        public string Symbol { get; }
        private bool[] _assignedAddress;

        public void AssignAddress(bool[] address)
        {
            _assignedAddress = address;
        }

        public override string Mnemonic => $"@{Symbol}";

        public override bool[] Bits
        {
            get
            {
                if (_assignedAddress == null)
                {
                    throw new Exception($"No address assigned for symbol{Symbol}");
                }

                return new[] {false}.Concat(_assignedAddress).ToArray();
            }
        }
    }
}