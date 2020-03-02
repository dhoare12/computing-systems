using System;
using System.Collections.Generic;
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

    public class PopCommand : IMemoryCommand
    {
        public PopCommand(MemSegment segment, int index)
        {
            Segment = segment;
            Index = index;
        }

        public MemSegment Segment { get; }
        public int Index { get; }
        public List<string> Compile(CompilerContext context)
        {
            throw new NotImplementedException();
        }
    }
}
