namespace ComputingSystems.VirtualMachine.Compiler.Commands.Arithmetic
{
    public class AndCommand : SimpleBinaryCommand
    {
        protected override string BinaryOperation => "M=D&M";
    }
}