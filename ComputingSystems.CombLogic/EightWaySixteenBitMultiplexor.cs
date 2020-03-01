using System.Linq;
using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;

namespace ComputingSystems.CombLogic
{
    public class EightWaySixteenBitMultiplexor : IEightWaySixteenBitMultiplexor
    {
        private readonly IEightWayMultiplexor[] _multiplexors = TypeProvider.GetArray<IEightWayMultiplexor>(16);

        public EightWaySixteenBitMultiplexor()
        {
            for (var i = 0; i < 16; i++)
            {
                for (var j = 0; j < 8; j++)
                {
                    _multiplexors[i].Input[j].AttachInput(Input[j][i]);
                }
                _multiplexors[i].Selector.AttachInputs(Selector);
            }
        }

        public IPin[][] Input { get; } = Enumerable.Range(0, 8).Select(_ => Pin.Array(16)).ToArray();

        public IPin[] Selector { get; } = Pin.Array(3);

        public IPin[] Output => _multiplexors.Select(m => m.Output).ToArray();
        
        public void Fill(IPin[][] input, IPin[] selector)
        {
            for (var i = 0; i < 8; i++)
            {
                Input[i].AttachInputs(input[i]);
            }
            Selector.AttachInputs(selector);
        }
    }
}