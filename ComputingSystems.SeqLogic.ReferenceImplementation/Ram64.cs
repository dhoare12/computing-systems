﻿using ComputingSystems.Core;
using ComputingSystems.SeqLogic.Interfaces;

namespace ComputingSystems.SeqLogic.ReferenceImplementation
{
    public class Ram64 : IRam64
    {
        public bool[] Address { get; set; }
        public bool Load { get; set; }
        public bool[] Input { get; set; }

        public bool[] Output { get; private set; } = BinaryUtils.EmptyArray(16);

        private readonly bool[][] _values = BinaryUtils.EmptyArray(64, 16);

        private bool _clock;
        public bool Clock
        {
            get => _clock;
            set
            {
                if (_clock != value)
                {
                    Output = _values[BinaryUtils.BitsToInt(Address, 6)];
                    if (Load)
                    {
                        _values[BinaryUtils.BitsToInt(Address, 6)] = Input;
                    }
                }

                _clock = value;
            }
        }
    }
}