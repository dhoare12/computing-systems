using System.Linq;
using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;

namespace ComputingSystems.CombLogic
{
    public class EightWayMultiplexor : IEightWayMultiplexor
    {
        public EightWayMultiplexor()
        {
            _bottomMultiplexors[0].Fill(Input[0], Input[1], Selector[2]);
            _bottomMultiplexors[1].Fill(Input[2], Input[3], Selector[2]);
            _bottomMultiplexors[2].Fill(Input[4], Input[5], Selector[2]);
            _bottomMultiplexors[3].Fill(Input[6], Input[7], Selector[2]);

            _middleMultiplexors[0].Fill(_bottomMultiplexors[0].Output, _bottomMultiplexors[1].Output, Selector[1]);
            _middleMultiplexors[1].Fill(_bottomMultiplexors[2].Output, _bottomMultiplexors[3].Output, Selector[1]);

            _topMultiplexor.Fill(_middleMultiplexors[0].Output, _middleMultiplexors[1].Output, Selector[0]);
        }

        private readonly IMultiplexor[] _bottomMultiplexors = TypeProvider.GetArray<IMultiplexor>(4);
        private readonly IMultiplexor[] _middleMultiplexors = TypeProvider.GetArray<IMultiplexor>(2);
        private readonly IMultiplexor _topMultiplexor = TypeProvider.Get<IMultiplexor>();

        public IPin[] Input { get; } = Enumerable.Range(0, 8).Select(_ => new Pin()).ToArray();

        public IPin[] Selector { get; }= Enumerable.Range(0, 3).Select(_ => new Pin()).ToArray();

        public IPin Output => _topMultiplexor.Output;
        public void Fill(IPin[] input, IPin[] selector)
        {
            for (var i = 0; i < 8; i++)
            {
                Input[i].AttachInput(input[i]);
            }

            for (var i = 0; i < 3; i++)
            {
                Selector[i].AttachInput(selector[i]);
            }
        }
    }
}