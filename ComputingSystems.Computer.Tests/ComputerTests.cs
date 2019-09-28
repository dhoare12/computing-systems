using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputingSystems.Computer.Tests
{
    [TestClass]
    public class ComputerTests
    {
        [TestMethod]
        public void ComputerTest()
        {
            var instructions = File
                .ReadAllLines("C:\\Temp\\outputBinary")
                .Select(x => x.ToCharArray().Select(c => c == '1').Reverse().ToArray())
                .ToArray();

            var computer = new Computer(instructions);

            computer.ClockTick();
            computer.ClockTick();
            computer.ClockTick();
            computer.ClockTick();
            computer.ClockTick();
        }
    }
}
