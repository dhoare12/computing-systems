using System.Linq;
using ComputingSystems.Core;

namespace ComputingSystems.CombLogic.ReferenceImplementations
{
    public class EightWaySixteenBitMultiplexor
    {
        private readonly EightWayMultiplexor[] _multiplexors = TypeProvider.GetArray<EightWayMultiplexor>(16);

        public bool[][] Inputs { get; set; } = BinaryUtils.EmptyArray(8, 16);

        public bool[] Selector { get; set; } = BinaryUtils.EmptyArray(3);

        public bool[] Output
        {
            get
            {
                for (var i = 0; i < 16; i++)
                {
                    _multiplexors[i].Input = Inputs.Select(input => input[i]).ToArray();
                    _multiplexors[i].Selector = Selector;
                }

                return _multiplexors.Select(m => m.Output).ToArray();
            }
        }
    }
}