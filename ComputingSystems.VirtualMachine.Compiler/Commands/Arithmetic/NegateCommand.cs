using System.Collections.Generic;

namespace ComputingSystems.VirtualMachine.Compiler.Commands.Arithmetic
{
    public class NegateCommand : IArithmeticCommand
    {
        public List<string> Compile(CompilerContext context)
        {
            return new List<string>
            {
                // Load SP-1 into A 
                "@SP",
                "A=M-1",
                // Set top of stack to negative of current value
                "M=-M"
            };
        }
    }
}