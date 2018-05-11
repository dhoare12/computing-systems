using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputingSystems.CombLogic.ReferenceImplementations;

namespace ComputingSystems.SeqLogic
{
    public class Ram8 : IClockedComponent
    {
        private readonly NBitRegister[] _registers = Enumerable.Range(0, 8).Select(_ => new NBitRegister(8)).ToArray();
        private readonly SixteenBitMultiplexor[] _bottomMultiplexors = SixteenBitMultiplexor.ArrayOf(4);
        private readonly SixteenBitMultiplexor[] _middleMultiplexors = SixteenBitMultiplexor.ArrayOf(2);
        private readonly SixteenBitMultiplexor _topMultiplexor = new SixteenBitMultiplexor();

        private readonly Demultiplexor _deMux = new Demultiplexor();

        public bool[] Address { get; set; }

        public bool Load { get; set; }
        public bool[] In { get; set; }

        private bool _clock;
        public bool Clock
        {
            get => _clock;
            set
            {
                _bottomMultiplexors[0].Fill(_registers[0].Outputs, _registers[1].Outputs, Address[2]);
                _bottomMultiplexors[1].Fill(_registers[2].Outputs, _registers[3].Outputs, Address[2]);
                _bottomMultiplexors[2].Fill(_registers[4].Outputs, _registers[5].Outputs, Address[2]);
                _bottomMultiplexors[3].Fill(_registers[6].Outputs, _registers[7].Outputs, Address[2]);

                _middleMultiplexors[0].Fill(_bottomMultiplexors[0].Output, _bottomMultiplexors[1].Output, Address[1]);
                _middleMultiplexors[1].Fill(_bottomMultiplexors[2].Output, _bottomMultiplexors[3].Output, Address[1]);

                _topMultiplexor.Fill(_middleMultiplexors[0].Output, _middleMultiplexors[1].Output, Address[0]);

                foreach (var register in _registers)
                {
                    register.Inputs = In;
                    register.Load = false;
                }

                // TODO: Logic for setting value
            }
        }

        public bool[] Out => _topMultiplexor.Output;
    }
}