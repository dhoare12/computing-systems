using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ComputingSystems.VirtualMachine.Compiler.Commands.Function;

namespace ComputingSystems.VirtualMachine.Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            //var pathToVmCode = args[0];

            while (true)
            {
                Loop();
                Console.ReadLine();
            }

            //Console.ReadLine();
        }

        static void Loop()
        {
            Console.Clear();
            var input = "C:\\Temp\\Nand2Tetris\\nand2tetris\\projects\\08\\FunctionCalls\\FibonacciElement\\";

            var files = new List<string>();
            string outputPath;

            if ((File.GetAttributes(input) & FileAttributes.Directory) != 0)
            {
                var directoryName = Path.GetFileName(Path.GetDirectoryName(input));
                outputPath = Path.Combine(input, directoryName + ".asm");
                files = Directory.EnumerateFiles(input, "*.vm", SearchOption.TopDirectoryOnly).ToList();
            }
            else
            {
                files.Add(input);
                var fileName = Path.GetFileName(input).Replace(".vm", "");
                outputPath = input.Replace(fileName + ".vm", fileName + ".asm");
            }

            var context = new CompilerContext(string.Empty);

            var outputLines = new List<string>
            {
                "@256",
                "D=A",
                "@SP",
                "M=D",
            }.Concat(new FunctionCallCommand("Sys.Init", 0).Compile(context)).ToList();

            foreach (var filePath in files)
            {
                context.FileName = Path.GetFileName(filePath).Replace(".vm", "");
                outputLines.AddRange(ParseFile(filePath, context));
            }
            
            File.WriteAllLines(outputPath, outputLines);
        }

        private static List<string> ParseFile(string input, CompilerContext context)
        {
            var outputLines = new List<string>();
            var lines = File.ReadAllLines(input).ToList();

            var parsedLines = new FileParser().Parse(lines);

            foreach (var line in parsedLines)
            {
                var cmd = new CommandParser().Parse(line);

                var compiledCode = cmd.Compile(context);
                Console.WriteLine($"// {line} ({compiledCode.Count} lines)");
                foreach (var compiledLine in compiledCode)
                {
                    Console.WriteLine(compiledLine);
                }
                outputLines.AddRange(compiledCode);
            }

            return outputLines;
        }
    }
}
