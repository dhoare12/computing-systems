using System.Collections.Generic;

namespace ComputingSystems.VirtualMachine.Compiler.Commands.Function
{
    public class FunctionCallCommand : ICommand
    {
        public FunctionCallCommand(string functionName, int numberOfArguments)
        {
            FunctionName = functionName;
            NumberOfArguments = numberOfArguments;
        }

        public string FunctionName { get; }
        public int NumberOfArguments { get; }

        public List<string> Compile(CompilerContext context)
        {
            var returnLabel = $"FunctionReturnLabel{context.FunctionReturnLabelsUsed}";
            context.FunctionReturnLabelsUsed++;

            var lines = new List<string>();
            // Push state of current function onto stack
            lines.AddRange(PushReference(returnLabel));
            lines.AddRange(PushReference("LCL"));
            lines.AddRange(PushReference("ARG"));
            lines.AddRange(PushReference("THIS"));
            lines.AddRange(PushReference("THAT"));

            // Reposition ARG = SP-n-5
            lines.AddRange(new []
            {
                "@SP",
                "D=M",
                "@ARG",
                "M=D",
                "@"+(5+NumberOfArguments),
                "D=A",
                "@ARG",
                "M=M-D"
            });

            // Reposition LCL = SP
            lines.AddRange(new []
            {
                "@SP",
                "D=M",
                "@LCL",
                "M=D"
            });

            // Goto f
            lines.AddRange(new []
            {
                $"@{FunctionName}",
                "0;JMP"
            });

            // Declare return label
            lines.Add($"({returnLabel})");

            return lines;
        }

        private static IEnumerable<string> PushReference(string refName)
        {
            return new[]
            {
                $"@{refName}",
                "D=M",
                "@SP",
                "A=M",
                "M=D",
                "@SP",
                "M=M+1"
            };
        }
    }
}