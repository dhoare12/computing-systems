using System.Collections.Generic;

namespace ComputingSystems.VirtualMachine.Compiler.Commands.Arithmetic
{
    public class EqualsCommand : IArithmeticCommand
    {
        public List<string> Compile(CompilerContext context)
        {
            var equalBlockLabel = "EqualityJump" + context.EqualityLabelsUsed;
            context.EqualityLabelsUsed++;

            var endBlockLabel = "EqualityJump" + context.EqualityLabelsUsed;
            context.EqualityLabelsUsed++;

            return new List<string>
            {
                // Decrement SP (to point at top item)
                "@SP",
                "M=M-1",
                "A=M",
                // Pop top of stack into D
                "D=M",
                // Decrement pointer to new top of stack
                "@SP",
                "M=M-1",
                "A=M",
                // Subtract from each other and store in D (D = y - x)
                "D=D-M",
                // Setup jump for case where values are equal
                "@"+equalBlockLabel,
                // Jump if D==0 (ie equal)
                "D;JEQ",
                // Numbers aren't equal. Set top of stack to false (0)
                "@SP",
                "A=M",
                "M=0",
                // Jump to end
                "@" + endBlockLabel,
                "0;JMP",
                // Equal block - Set top of stack to true (-1)
                $"({equalBlockLabel})",
                "@SP",
                "A=M",
                "M=-1",
                $"({endBlockLabel})",
                // Increment SP
                "@SP",
                "M=M+1"

            };
        }
    }
}