using System.Linq;
using ComputingSystems.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputingSystems.Computer.Tests
{
    [TestClass]
    public class CpuTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var cpu = new Cpu
            {
                Inputs = new CpuInputs()
            };

            cpu.Inputs.Instruction.AttachInput("0101010101010101".ToBinary().ToBus());
            cpu.Inputs.InM.AttachInput("1010101010101010".ToBinary().ToBus());
            cpu.Inputs.Reset.AttachInput(false.ToPin());

            cpu.Refresh();

            Assert.IsFalse(cpu.Outputs.WriteM.Value);


        }
    }
}