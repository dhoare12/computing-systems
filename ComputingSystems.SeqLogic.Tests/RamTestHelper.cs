using ComputingSystems.SeqLogic.Interfaces;

namespace ComputingSystems.SeqLogic.Tests
{
    public class RamTestHelper
    {
        private readonly IRam _ram;

        public RamTestHelper(IRam ram)
        {
            _ram = ram;
        }

        public bool[] Read(bool[] address)
        {
            _ram.Address = address;
            _ram.Load = false;
            _ram.Clock = !_ram.Clock;
            return _ram.Output;
        }

        public void Write(bool[] address, bool[] value)
        {
            _ram.Address = address;
            _ram.Input = value;
            _ram.Load = true;
            _ram.Clock = !_ram.Clock;
        }
    }
}
