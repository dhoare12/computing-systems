using System.Collections.Generic;

namespace ComputingSystems.VirtualMachine.Compiler.Commands.Arithmetic
{
    public class GreaterThanCommand : IArithmeticCommand
    {
        public List<string> Compile(CompilerContext context)
        {
            var label1 = "EqualityJump" + context.EqualityLabelsUsed;
            context.EqualityLabelsUsed++;
            var label2 = "EqualityJump" + context.EqualityLabelsUsed;
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
                // Setup jump for case where values are equal
                "@"+label1,
                // Subtract from each other, jump if result>0 (meaning x>y true case) 
                "D-M;JGT",
                // We didn't jump - false case. Set top of stack to 0 and jump out
                "M=0",
                $"@{label2}",
                "0;JMP",
                $"({label1})",
                // Handle true case
                "M=-1",
                $"({label2})"
            };
        }
    }
}