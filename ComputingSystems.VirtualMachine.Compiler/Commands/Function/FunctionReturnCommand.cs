using System.Collections.Generic;

namespace ComputingSystems.VirtualMachine.Compiler.Commands.Function
{
    public class FunctionReturnCommand : ICommand
    {
        public List<string> Compile(CompilerContext context)
        {
            context.FunctionName = null;

            var lines = new List<string>();

            // (R13) FRAME = LCL
            lines.AddRange(new []
            {
                "@LCL",
                "D=M",
                "@R13",
                "M=D"
            });

            // (R14) RET = *(FRAME-5)
            lines.AddRange(new []
            {
                "@5",
                "D=D-A",
                "A=D",
                "D=M",
                "@R14",
                "M=D"
            });

            // *ARG = pop()
            lines.AddRange(new []
            {
                "@SP",
                "M=M-1",
                "A=M",
                "D=M",
                "@ARG",
                "A=M",
                "M=D"
            });

            // SP = ARG + 1
            lines.AddRange(new []
            {
                "D=A+1",
                "@SP",
                "M=D"
            });

            // THAT = *(FRAME-1)
            lines.AddRange(new []
            {
                "@R13",
                "AM=M-1",
                "D=M",
                "@THAT",
                "M=D"
            });

            // THIS = *(FRAME-2)
            lines.AddRange(new []
            {
                "@R13",
                "AM=M-1",
                "D=M",
                "@THIS",
                "M=D"
            });

            // ARG = *(FRAME-3)
            lines.AddRange(new []
            {
                "@R13",
                "AM=M-1",
                "D=M",
                "@ARG",
                "M=D"
            });

            // LCL = *(FRAME-4)
            lines.AddRange(new []
            {
                "@R13",
                "AM=M-1",
                "D=M",
                "@LCL",
                "M=D"
            });

            // goto RET
            lines.AddRange(new []
            {
                "@R14",
                "A=M",
                "0;JMP"
            });

            return lines;
        }
    }
}