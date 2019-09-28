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
                Inputs = new CpuInputs
                {
                    Instruction = "0101010101010101".ToBinary().Reverse().ToArray(),
                    InM = "1010101010101010".ToBinary(),
                    Reset = false
                },
                Outputs = new CpuOutputs
                {
                    
                }
            };

            cpu.Refresh();

            Assert.IsFalse(cpu.Outputs.WriteM);


        }
    }
}