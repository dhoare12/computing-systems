using System.Linq;

namespace ComputingSystems.CombLogic.ReferenceImplementations
{
    public class Multiplexor : ThreeInputGate, ISingleOutputGate
    {
        // Input3 = control
        public bool Output => Input3 ? Input2 : Input1;

        public static Multiplexor[] ArrayOf(int count) => Enumerable.Range(0, count).Select(_ => new Multiplexor()).ToArray();
    }

    public class EightWayMultiplexor
    {
        private readonly Multiplexor[] _bottomMultiplexors = Multiplexor.ArrayOf(4);
        private readonly Multiplexor[] _middleMultiplexors = Multiplexor.ArrayOf(2);
        private readonly Multiplexor _topMultiplexor = new Multiplexor();

        public bool[] Input { get; set; }

        public bool[] Selector { get; set; }

        public bool Output
        {
            get
            {
                _bottomMultiplexors[0].Fill(Input[0], Input[1], Selector[2]);
                _bottomMultiplexors[1].Fill(Input[2], Input[3], Selector[2]);
                _bottomMultiplexors[2].Fill(Input[4], Input[5], Selector[2]);
                _bottomMultiplexors[3].Fill(Input[6], Input[7], Selector[2]);

                _middleMultiplexors[0].Fill(_bottomMultiplexors[0].Output, _bottomMultiplexors[1].Output, Selector[1]);
                _middleMultiplexors[1].Fill(_bottomMultiplexors[2].Output, _bottomMultiplexors[3].Output, Selector[1]);

                _topMultiplexor.Fill(_middleMultiplexors[0].Output, _middleMultiplexors[1].Output, Selector[0]);

                return _topMultiplexor.Output;
            }
        }

        public static EightWayMultiplexor[] ArrayOf(int count) => Enumerable.Range(0, count).Select(_ => new EightWayMultiplexor()).ToArray();
    }

    public class EightWaySixteenBitMultiplexor
    {
        private readonly EightWayMultiplexor[] _multiplexors = EightWayMultiplexor.ArrayOf(16);

        public bool[][] Inputs { get; set; } = Enumerable.Range(0, 8).Select(_ => Enumerable.Range(0, 16).Select(x => false).ToArray()).ToArray();

        public bool[] Selector { get; set; } = Enumerable.Range(0, 3).Select(_ => false).ToArray();

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