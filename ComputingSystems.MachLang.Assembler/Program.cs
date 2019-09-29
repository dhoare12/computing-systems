using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ComputingSystems.Core;
using ComputingSystems.MachLang.Instructions;

namespace ComputingSystems.MachLang.Assembler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string filePath;
            if (args.Length < 2)
            {
                Console.WriteLine("Path to assembly file?");
                filePath = Console.ReadLine();
            }
            else
            {
                filePath = args[1];
            }
            var file = File.ReadAllLines(filePath);

            var parser = new InstructionParser();

            var parsedLines = file
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(parser.Parse)
                .ToList();

            var variableSymbols = PredefinedSymbols.GetSymbols();
            var nextSymbolAddress = 16;
            var nextInstructionAddress = 0;

            foreach (var line in parsedLines)
            {
                switch (line)
                {
                    case LabelLine labelLine when variableSymbols.ContainsKey(labelLine.Label):
                        throw new Exception($"Duplicate label {labelLine.Label} defined");
                    case LabelLine labelLine:
                        variableSymbols[labelLine.Label] = nextInstructionAddress;
                        break;
                    case IInstruction _:
                        nextInstructionAddress++;
                        break;
                }
            }
            
            foreach (var symbolInstruction in parsedLines.OfType<ASymbolInstruction>())
            {
                if (!variableSymbols.ContainsKey(symbolInstruction.Symbol))
                {
                    variableSymbols[symbolInstruction.Symbol] = nextSymbolAddress;
                    nextSymbolAddress++;
                }

                symbolInstruction.AssignAddress(BinaryUtils.FifteenBitIntToBits(variableSymbols[symbolInstruction.Symbol]));
            }

            File.WriteAllLines("C:\\Temp\\Nand2Tetris\\outputBinary.hdb", variableSymbols.Select(x => $"{x.Key}={x.Value}"));

            Console.ForegroundColor = ConsoleColor.White;

            try
            {
                var outputLines = parsedLines
                    .OfType<IInstruction>()
                    .Select(x => x.Bits.ToStringRepresentation())
                    .ToList();

                File.WriteAllLines("C:\\Temp\\Nand2Tetris\\outputBinary.hack", outputLines);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Assembler error!");
                Console.WriteLine(ex);
            }
            
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
