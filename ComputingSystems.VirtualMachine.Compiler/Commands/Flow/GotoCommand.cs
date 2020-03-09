using System.Collections.Generic;

namespace ComputingSystems.VirtualMachine.Compiler.Commands.Flow
{
    public class GotoCommand : ICommand
    {
        public GotoCommand(string symbol)
        {
            Symbol = symbol;
        }

        public string Symbol { get; }

        public List<string> Compile(CompilerContext context)
        {
            var labelName = $"{context.FunctionName}${Symbol}";

            return new List<string>
            {
                $"@{labelName}",
                "0;JMP"
            };
        }
    }
}