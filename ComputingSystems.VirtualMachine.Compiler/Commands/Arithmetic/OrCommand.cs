namespace ComputingSystems.VirtualMachine.Compiler.Commands.Arithmetic
{
    public class OrCommand : SimpleBinaryCommand
    {
        protected override string BinaryOperation => "M=D|M";
    }
}