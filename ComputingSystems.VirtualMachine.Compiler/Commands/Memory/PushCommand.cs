﻿using System;
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
            switch (Segment)
            {
                case MemSegment.Constant:
                    return CompileConstant();
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

        private List<string> CompileConstant()
        {
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

        private List<string> CompileAbsoluteSegment(int baseIndex)
        {
            var index = baseIndex + Index;
            return new List<string>
            {
                // Load pointer into A
                "@" + index,
                // Load value into D
                "D=M",
                // Set mem at SP to D
                "@SP",
                "A=M",
                "M=D",
                // Increment SP
                "@SP",
                "M=M+1"
            };
        }

        private List<string> CompileReferenceSegment(string basePointerName)
        {
            return new List<string>
            {
                // Load index into D
                "@"+Index,
                "D=A",
                // Load base pointer into A
                "@"+basePointerName,
                "A=M",
                // Add index
                "A=A+D",
                // Load value into D
                "D=M",
                // Set mem at SP to D
                "@SP",
                "A=M",
                "M=D",
                // Increment SP
                "@SP",
                "M=M+1"
            };
        }

        private List<string> CompileStaticSegment(CompilerContext context)
        {
            var labelName = context.FileName + "." + Index;

            return new List<string>
            {
                // Load static value into D
                "@" + labelName,
                "D=M",
                // Push D onto top of stack
                "@SP",
                "A=M",
                "M=D",
                // Increment SP
                "@SP",
                "M=M+1"
            };
        }
    }
}