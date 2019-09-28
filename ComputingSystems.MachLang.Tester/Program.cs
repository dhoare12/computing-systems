using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ComputingSystems.Core;
using ComputingSystems.MachLang.Instructions;

namespace ComputingSystems.MachLang.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = File.ReadAllLines("C:\\Temp\\machineLanguage.txt");

            var parser = new InstructionParser();

            var parsedLines = file
                .Select(parser.Parse)
                .ToList();

            var variableSymbols = new Dictionary<string, int>();
            var nextSymbolAddress = 16;
            var nextInstructionAddress = 0;

            foreach (var line in parsedLines)
            {
                if (line is LabelLine labelLine)
                {
                    if (variableSymbols.ContainsKey(labelLine.Label))
                    {
                        throw new Exception($"Duplicate label {labelLine.Label} defined");
                    }

                    variableSymbols[labelLine.Label] = nextInstructionAddress;
                }

                if (line is IInstruction)
                {
                    nextInstructionAddress++;
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

            Console.ForegroundColor = ConsoleColor.White;


            foreach (var parsedLine in parsedLines)
            {
                if (parsedLine is IInstruction instruction)
                {
                    try
                    {
                        Console.WriteLine(instruction.Bits.ToStringRepresentation().FormatNicely() + " " + instruction.Mnemonic);
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(ex.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }
            }

            File.WriteAllLines("C:\\Temp\\outputBinary", parsedLines.OfType<IInstruction>().Select(x => x.Bits.ToStringRepresentation().FormatNicely()));

            Console.ReadLine();
        }
    }

    public static class StringExtensions
    {
        public static string FormatNicely(this string str)
        {
            return str.Substring(0, 4) + " " + str.Substring(4, 4) + " " + str.Substring(8, 4) + " " +
                   str.Substring(12, 4);
        }
    }
}
