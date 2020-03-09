using System;
using System.Collections.Generic;

namespace ComputingSystems.VirtualMachine.Compiler.Commands.Memory
{
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
            switch (Segment)
            {
                case MemSegment.Constant:
                    throw new NotSupportedException("No popping constants");
                case MemSegment.Local:
                    return CompileReferenceSegment("LCL");
                case MemSegment.Argument:
                    return CompileReferenceSegment("ARG");
                case MemSegment.This:
                    return CompileReferenceSegment("THIS");
                case MemSegment.That:
                    return CompileReferenceSegment("THAT");
                case MemSegment.Pointer:
                    return CompileAbsoluteSegment(3);
                case MemSegment.Temp:
                    return CompileAbsoluteSegment(5);
                case MemSegment.Static:
                    return CompileStaticSegment(context);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private List<string> CompileAbsoluteSegment(int absoluteBase)
        {
            var index = absoluteBase + Index;
            
            return new List<string>
            {
                // Pop top of stack (value to pop) into D
                "@SP",
                "M=M-1",
                "A=M",
                "D=M",
                // Set memory value to D
                "@"+index,
                "M=D"
            };
        }

        private List<string> CompileReferenceSegment(string referenceBaseName)
        {
            return new List<string>
            {
                // Put mem address into D
                "@"+referenceBaseName,
                "D=M",
                "@"+Index,
                "D=D+A",
                // Put D (mem address) on top of stack
                "@SP",
                "M=M-1",
                "A=M+1",
                "M=D",
                // Pop top of stack (value to pop) into D
                "A=A-1",
                "D=M",
                // Set mem to D (value to pop)
                "A=A+1",
                "A=M",
                "M=D"
            };
        }

        private List<string> CompileStaticSegment(CompilerContext context)
        {
            var refName = context.FileName + "." + Index;

            return new List<string>
            {
                // Pop top of stack into D
                "@SP",
                "M=M-1",
                "A=M",
                "D=M",
                // Point to static ref
                "@"+refName,
                // Set value
                "M=D"
            };
        }
    }
}