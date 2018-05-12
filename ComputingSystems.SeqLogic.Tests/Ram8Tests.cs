using ComputingSystems.CombLogic.ReferenceImplementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputingSystems.SeqLogic.Tests
{
    [TestClass]
    public class RamTests
    {
        public RamTests()
        {
            CombLogicReferenceImplementationsTypeModule.Bind(rebind: true);
            SeqLogicTypeModule.Bind(rebind: true);
        }

        [TestMethod]
        public void Ram8BehavesCorrectly()
        {
            var ram = new Ram8();
            new RamTest(ram, addressLength: 3).Run();
        }

        [TestMethod]
        public void Ram64BehavesCorrectly()
        {
            var ram = new Ram64();
            new RamTest(ram, addressLength: 6).Run();
        }

        [TestMethod]
        public void Ram512BehavesCorrectly()
        {
            var ram = new Ram512();
            new RamTest(ram, addressLength: 9).Run();
        }

        [TestMethod]
        [Ignore("Takes ages")]
        public void Ram4kBehavesCorrectly()
        {
            var ram = new Ram4k();
            new RamTest(ram, addressLength: 12).Run();
        }

        [TestMethod]
        [Ignore("Takes literally forever")]
        public void Ram16kBehavesCorrectly()
        {
            var ram = new Ram16k();
            new RamTest(ram, addressLength: 14).Run();
        }
    }
}
