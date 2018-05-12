using System.Linq;
using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;

namespace ComputingSystems.CombLogic
{
    public class EightWaySixteenBitMultiplexor : IEightWaySixteenBitMultiplexor
    {
        private readonly IEightWayMultiplexor[] _multiplexors = TypeProvider.GetArray<IEightWayMultiplexor>(16);

        public bool[][] Input { get; set; } = BinaryUtils.EmptyArray(8, 16);

        public bool[] Selector { get; set; } = BinaryUtils.EmptyArray(3);

        public bool[] Output
        {
            get
            {
                for (var i = 0; i < 16; i++)
                {
                    _multiplexors[i].Input = Input.Select(input => input[i]).ToArray();
                    _multiplexors[i].Selector = Selector;
                }

                return _multiplexors.Select(m => m.Output).ToArray();
            }
        }
    }
}