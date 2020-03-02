using System;
using System.Collections.Generic;

namespace ComputingSystems.VirtualMachine.Compiler.Commands.Memory
{
    public class PushCommand : IMemoryCommand
    {
        public PushCommand(MemSegment segment, int index)
        {
            Segment = segment;
            Index = index;
        }

        public MemSegment Segment { get; }
        public int Index { get; }

        public List<string> Compile(CompilerContext context)
        {
            if (Segment != MemSegment.Constant)
            {
                throw new NotImplementedException();
            }
            return new List<string>
            {
                // Load constant into D
                "@"+Index,
                "D=A",
                // Load SP into A
                "@SP",
                "A=M",
                // Set Mem at SP to D
                "M=D",
                // Increment SP
                "@SP",
                "M=M+1"
            };
        }
    }
}