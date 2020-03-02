using System;
using ComputingSystems.VirtualMachine.Compiler.Commands;
using ComputingSystems.VirtualMachine.Compiler.Commands.Arithmetic;
using ComputingSystems.VirtualMachine.Compiler.Commands.Flow;
using ComputingSystems.VirtualMachine.Compiler.Commands.Function;
using ComputingSystems.VirtualMachine.Compiler.Commands.Memory;

namespace ComputingSystems.VirtualMachine.Compiler
{
    public class CommandParser
    {
        public ICommand Parse(ParsedLine line)
        {
            switch (line.Command)
            {
                case "add":
                    return new AddCommand();
                case "sub":
                    return new SubtractCommand();
                case "neg":
                    return new NegateCommand();
                case "eq":
                    return new EqualsCommand();
                case "gt":
                    return new GreaterThanCommand();
                case "lt":
                    return new LessThanCommand();
                case "and":
                    return new AndCommand();
                case "or":
                    return new OrCommand();
                case "not":
                    return new NotCommand();
                case "push":
                    return new PushCommand(Enum.Parse<MemSegment>(line.Args[0], true), int.Parse(line.Args[1]));
                case "pop":
                    return new PopCommand(Enum.Parse<MemSegment>(line.Args[0], true), int.Parse(line.Args[1]));
                case "label":
                    return new LabelDeclarationCommand(line.Args[0]);
                case "goto":
                    return new GotoCommand(line.Args[0]);
                case "if-goto":
                    return new IfGotoCommand(line.Args[0]);
                case "function":
                    return new FunctionDeclarationCommand(line.Args[0], int.Parse(line.Args[1]));
                case "call":
                    return new FunctionCallCommand(line.Args[0], int.Parse(line.Args[1]));
                case "return":
                    return new FunctionReturnCommand();
                default:
                    throw new InvalidOperationException($"Unknown command {line.Command}");
            }
        }
    }
}
