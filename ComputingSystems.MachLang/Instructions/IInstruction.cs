namespace ComputingSystems.MachLang.Instructions
{
    public interface IInstruction
    {
        string Mnemonic { get; }
        bool[] Bits { get; }
    }
}