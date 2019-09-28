using System.IO;
using System.Linq;
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
                var instruction = parser.Parse(line);

                Assert.AreEqual(line, instruction.Mnemonic);
            }
        }
    }
}
