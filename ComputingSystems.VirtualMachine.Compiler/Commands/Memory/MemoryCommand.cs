using ComputingSystems.VirtualMachine.Compiler.Commands.Arithmetic;

namespace ComputingSystems.VirtualMachine.Compiler.Commands.Memory
{
    public enum MemSegment
    {
        Argument,
        Local,
        Static,
        Constant,
        This,
        That,
        Pointer,
        Temp
    }

    public interface IMemoryCommand : ICommand
    {
        MemSegment Segment { get; }
        int Index { get; }
    }
}
