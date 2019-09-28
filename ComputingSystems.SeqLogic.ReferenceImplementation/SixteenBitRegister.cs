using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputingSystems.SeqLogic.Interfaces;

namespace ComputingSystems.SeqLogic.ReferenceImplementation
{
    public class SixteenBitRegister : IClockedComponent
    {
        private bool[] _value = Enumerable.Range(0, 16).Select(_ => false).ToArray();

        public bool Clock
        {
            get => throw new NotImplementedException();
            set
            {
                if (Load)
                {
                    _value = Input;
                }
            }
        }

        public bool[] Input { get; set; }

        public bool Load { get; set; }

        public bool[] Output => _value;
    }
}
