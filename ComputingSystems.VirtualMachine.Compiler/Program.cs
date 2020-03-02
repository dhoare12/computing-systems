using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            var input = "C:\\Temp\\Nand2Tetris\\DaveTest.vm";
            var output = "C:\\Temp\\Nand2Tetris\\DaveTest.asm";

            var lines = File.ReadAllLines(input).ToList();

            var parsedLines = new FileParser().Parse(lines);

            var outputLines = new List<string>();

            var context = new CompilerContext();
            foreach (var line in parsedLines)
            {
                var cmd = new CommandParser().Parse(line);

                outputLines.AddRange(cmd.Compile(context));
            }

            var i = 0;
            foreach (var line in outputLines)
            {
                i++;
                Console.WriteLine(i + " " + line);
            }

            File.WriteAllLines(output, outputLines);
            
        }
    }
}
