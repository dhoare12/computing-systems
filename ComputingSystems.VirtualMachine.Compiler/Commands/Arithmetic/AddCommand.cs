namespace ComputingSystems.VirtualMachine.Compiler.Commands.Arithmetic
{
    public class AddCommand : SimpleBinaryCommand
    {
        protected override string BinaryOperation => "M=M+D";
    }
}