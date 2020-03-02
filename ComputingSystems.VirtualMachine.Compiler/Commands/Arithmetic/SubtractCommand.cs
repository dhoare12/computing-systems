using System.Collections.Generic;

namespace ComputingSystems.VirtualMachine.Compiler.Commands.Arithmetic
{
    public class SubtractCommand : SimpleBinaryCommand
    {
        protected override string BinaryOperation => "M=M-D";
    }
}