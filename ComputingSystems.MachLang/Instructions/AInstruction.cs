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
        public override bool[] Bits { get; }
    }

    public class ASymbolInstruction : AInstruction
    {
        private readonly string _symbol;

        public ASymbolInstruction(string symbol)
        {
            _symbol = symbol;
        }

        public override string Mnemonic => $"@{_symbol}";
        public override bool[] Bits { get; }
    }
}