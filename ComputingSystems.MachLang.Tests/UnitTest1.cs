using System;
using System.IO;
using System.Linq;
using ComputingSystems.MachLang.Instructions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputingSystems.MachLang.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ParseFile()
        {
            var file = File.ReadAllLines("C:\\Temp\\machineLanguage.txt");

            var parser = new InstructionParser();

            foreach (var line in file)
            {
                var parsedLine = parser.Parse(line);

                if (parsedLine is IInstruction instruction)
                {
                    try
                    {
                        Console.WriteLine(instruction.Bits.ToStringRepresentation() + " " + instruction.Mnemonic);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                }
            }
        }
    }
}
