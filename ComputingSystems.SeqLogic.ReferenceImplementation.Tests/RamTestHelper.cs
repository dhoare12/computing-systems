using ComputingSystems.Core;
using ComputingSystems.SeqLogic.Interfaces;

namespace ComputingSystems.SeqLogic.ReferenceImplementation.Tests
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
            _ram.Address.AttachInput(address.ToBus());
            _ram.Load.AttachInput(false.ToPin());
            _ram.Clock = !_ram.Clock;
            return _ram.Output.ToBits();
        }

        public void Write(bool[] address, bool[] value)
        {
            _ram.Address.AttachInput(address.ToBus());
            _ram.Input.AttachInput(value.ToBus());
            _ram.Load.AttachInput(true.ToPin());
            _ram.Clock = !_ram.Clock;
        }
    }
}
