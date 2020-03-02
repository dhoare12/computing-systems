using System.Collections.Generic;

namespace ComputingSystems.VirtualMachine.Compiler.Commands.Arithmetic
{
    public class EqualsCommand : IArithmeticCommand
    {
        public List<string> Compile(CompilerContext context)
        {
            var labelName = "EqualityJump" + context.EqualityLabelsUsed;
            context.EqualityLabelsUsed++;

            return new List<string>
            {
                // Decrement SP (to point at top item)
                "@SP",
                "M=M-1",
                // Load SP into A
                "A=M",
                // Pop top of stack into D
                "D=M",
                // Decrement pointer to new top of stack
                "A=A-1",
                // Subtract from each other, store value in D and M and jump to label if M=0
                "DM=D-M",
                // Setup jump for case where values are equal
                "@"+labelName,
                "M=D-M;JEQ",
                // Numbers aren't equal. Set M to 1, so it becomes 0 (representing false) in next line
                "@SP",
                "A=A-1",
                "M=1",
                $"({labelName})",
                "@SP",
                "A=A-1",
                "M=M-1"
            };
        }
    }
}