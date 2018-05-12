using System.Linq;
using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;
using ComputingSystems.SeqLogic.Interfaces;

namespace ComputingSystems.SeqLogic
{
    public class Ram4k : IRam4k
    {
        private readonly Ram512[] _ram = Ram512.ArrayOf(8);
        private readonly IEightWaySixteenBitMultiplexor _mux = TypeProvider.Get<IEightWaySixteenBitMultiplexor>();
        private readonly IEightWayDemultiplexor _demux = TypeProvider.Get<IEightWayDemultiplexor>();

        public bool[] Address { get; set; } = "000 000 000 000".ToBinary(); // Twelve bits
        private bool[] AddressMostSignificant => new[] {Address[0], Address[1], Address[2]};
        private bool[] AddressLeastSignificant => new[] {Address[3], Address[4], Address[5], Address[6], Address[7], Address[8], Address[9], Address[10], Address[11]};

        public bool[] Input { get; set; } = "00000000 00000000".ToBinary();

        public bool Load { get; set; }

        public bool[] Output => _mux.Output;

        private bool _clock;
        public bool Clock
        {
            get => _clock;
            set
            {
                foreach (var ram in _ram)
                {
                    ram.Address = AddressLeastSignificant;
                    ram.Input = Input;
                    ram.Load = false;
                }
                

                _demux.Selector = AddressMostSignificant;
                _demux.Input = Load;

                for (var i = 0; i < _ram.Length; i++)
                {
                    _ram[i].Input = Input;
                    _ram[i].Load = _demux.Output[i];
                }

                _clock = value;

                foreach (var ram in _ram)
                {
                    ram.Clock = value;
                }
                _mux.Input = _ram.Select(r => r.Output).ToArray();
                _mux.Selector = AddressMostSignificant;
            }
        }

        public static Ram4k[] ArrayOf(int count) => Enumerable.Range(0, count).Select(_ => new Ram4k()).ToArray();
    }
}