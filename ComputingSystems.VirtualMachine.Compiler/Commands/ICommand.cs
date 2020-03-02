using System.Collections.Generic;

namespace ComputingSystems.VirtualMachine.Compiler.Commands
{
    public interface ICommand
    {
        List<string> Compile(CompilerContext context);
    }
}