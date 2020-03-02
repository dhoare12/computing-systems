using System.Collections.Generic;
using ComputingSystems.VirtualMachine.Compiler.Commands.Arithmetic;

namespace ComputingSystems.VirtualMachine.Compiler.Commands.Function
{
    public interface IFunctionCommand : ICommand
    {
        
    }

    public class FunctionDeclarationCommand : IFunctionCommand
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
            throw new System.NotImplementedException();
        }
    }

    public class FunctionCallCommand : IFunctionCommand
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
            throw new System.NotImplementedException();
        }
    }

    public class FunctionReturnCommand : IFunctionCommand
    {
        public List<string> Compile(CompilerContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}