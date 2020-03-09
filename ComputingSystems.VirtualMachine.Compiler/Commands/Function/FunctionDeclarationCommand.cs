using System.Collections.Generic;
using System.Linq;

namespace ComputingSystems.VirtualMachine.Compiler.Commands.Function
{
    public class FunctionDeclarationCommand : ICommand
    {
        public FunctionDeclarationCommand(string functionName, int numberOfLocals)
        {
            FunctionName = functionName;
            NumberOfLocals = numberOfLocals;
        }

        public string FunctionName { get; }
        public int NumberOfLocals { get; }

        public List<string> Compile(CompilerContext context)
        {
            context.FunctionName = FunctionName;

            var lines = new List<string>
            {
                // Label for function entry
                $"({FunctionName})", 
                // Prep for next step
                "@SP"
            };

            // Initialise all locals to 0
            for (var i = 0; i < NumberOfLocals; i++)
            {
                lines.AddRange(new []
                {
                    "A=M",
                    "M=0",
                    "@SP",
                    "M=M+1"
                });
            }

            return lines;
        }
    }
}