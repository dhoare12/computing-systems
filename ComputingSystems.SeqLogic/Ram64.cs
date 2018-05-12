using System.Linq;
using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;
using ComputingSystems.SeqLogic.Interfaces;

namespace ComputingSystems.SeqLogic
{
    public class Ram64 : IRam64
    {
        private readonly Ram8[] _ram = Ram8.ArrayOf(8);
        private readonly IEightWaySixteenBitMultiplexor _mux = TypeProvider.Get<IEightWaySixteenBitMultiplexor>();
        private readonly IEightWayDemultiplexor _demux = TypeProvider.Get<IEightWayDemultiplexor>();

        public bool[] Address { get; set; } = "000 000".ToBinary(); // Six bits
        private bool[] AddressMostSignificant => new[] {Address[0], Address[1], Address[2]};
        private bool[] AddressLeastSignificant => new[] {Address[3], Address[4], Address[5]};

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

        public static Ram64[] ArrayOf(int count) => Enumerable.Range(0, count).Select(_ => new Ram64()).ToArray();
    }
}