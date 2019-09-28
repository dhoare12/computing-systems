namespace ComputingSystems.MachLang.Instructions
{
    public interface IInstruction : IAssemblyLine
    {
        string Mnemonic { get; }
        bool[] Bits { get; }
    }

    public interface IAssemblyLine
    {

    }

    public class LabelLine : IAssemblyLine
    {
        public LabelLine(string label)
        {
            Label = label;
        }

        public string Label { get; }
    }
}