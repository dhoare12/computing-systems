using System.Collections.Generic;

namespace ComputingSystems.VirtualMachine.Compiler.Commands.Flow
{
    public class IfGotoCommand : ICommand
    {
        public IfGotoCommand(string symbol)
        {
            Symbol = symbol;
        }

        public string Symbol { get; }

        public List<string> Compile(CompilerContext context)
        {
            var labelName = $"{context.FunctionName}${Symbol}";

            return new List<string>
            {
                // Pop top of stack into D
                "@0",
                "M=M-1",
                "A=M",
                "D=M",
                // Load jump addr into A
                $"@{labelName}",
                // Jump if D not zero
                "D;JNE"
            };
        }
    }
}