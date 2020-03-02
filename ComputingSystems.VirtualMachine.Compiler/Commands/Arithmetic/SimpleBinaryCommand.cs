using System.Collections.Generic;

namespace ComputingSystems.VirtualMachine.Compiler.Commands.Arithmetic
{
    public abstract class SimpleBinaryCommand : IArithmeticCommand
    {
        public List<string> Compile(CompilerContext context)
        {
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
                // Set top of stack to current value + D
                BinaryOperation
            };
        }

        protected abstract string BinaryOperation { get; }
    }
}