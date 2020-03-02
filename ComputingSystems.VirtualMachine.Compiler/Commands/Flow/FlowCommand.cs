using System.Collections.Generic;
using ComputingSystems.VirtualMachine.Compiler.Commands.Arithmetic;

namespace ComputingSystems.VirtualMachine.Compiler.Commands.Flow
{
    public interface IFlowCommand : ICommand 
    {
        string Symbol { get; }
    }

    public class LabelDeclarationCommand : IFlowCommand
    {
        public LabelDeclarationCommand(string symbol)
        {
            Symbol = symbol;
        }

        public string Symbol { get; }
        public List<string> Compile(CompilerContext context)
        {
            throw new System.NotImplementedException();
        }
    }

    public class GotoCommand : IFlowCommand
    {
        public GotoCommand(string symbol)
        {
            Symbol = symbol;
        }

        public string Symbol { get; }
        public List<string> Compile(CompilerContext context)
        {
            throw new System.NotImplementedException();
        }
    }

    public class IfGotoCommand : IFlowCommand
    {
        public IfGotoCommand(string symbol)
        {
            Symbol = symbol;
        }

        public string Symbol { get; }
        public List<string> Compile(CompilerContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}