using System;
using System.Globalization;
using System.IO;
using System.Linq;
using ComputingSystems.MachLang;

namespace ComputingSystems.Computer.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Path to machine code?");*/
            var code = File.ReadAllLines("C:\\Temp\\Nand2Tetris\\outputBinary.hack")
                .Select(x => x.ToCharArray().Select(c => c == '1').ToArray())
                .ToArray();

            var lastLineOfCode = code.Length - 1;

            //Console.WriteLine("Path to hdb?");

            var hdb = File.ReadAllLines("C:\\Temp\\Nand2Tetris\\outputBinary.hdb")
                .Select(x => x.Split('='))
                .ToDictionary(x => x[0], x => int.Parse(x[1]));

            

            var computer = new Computer(code);

            while (true)
            {
                Console.Write("Prep memory? Address: ");
                if (int.TryParse(Console.ReadLine(), out var address))
                {
                    Console.Write("Val: ");
                    var val = int.Parse(Console.ReadLine());
                    computer.SetDataValue(address, val);
                }
                else
                {
                    break;
                }
            }

            var maxSymbolLength = hdb.Keys.Max(x => x.Length);

            var interpreter = new Interpreter();

            var i = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Cycle {i}");
                computer.ClockTick();
                Console.WriteLine($"{computer.CurrentInstruction} - {interpreter.Interpret(computer.CurrentInstructionBits)}");
                Console.WriteLine($"{"PC".PadLeft(maxSymbolLength)}={computer.ProgramCounter}");
                Console.WriteLine($"{"D".PadLeft(maxSymbolLength)}={computer.D}");
                Console.WriteLine($"{"A".PadLeft(maxSymbolLength)}={computer.A}");
                foreach (var (symbol, address) in hdb)
                {
                    var value = computer.GetDataValue(address);
                    Console.WriteLine($"{symbol.PadLeft(maxSymbolLength)}={value}");
                }

                Console.ReadLine();
                i++;

                if (computer.ProgramCounter > lastLineOfCode)
                {
                    break;
                }
            }

            Console.WriteLine("Program finished!");

            while (true)
            {
                Console.Write("Inspect memory? Pos: ");
                if (int.TryParse(Console.ReadLine(), out var address))
                {
                    Console.WriteLine(computer.GetDataValue(address));
                }
            }
        }
    }
}
