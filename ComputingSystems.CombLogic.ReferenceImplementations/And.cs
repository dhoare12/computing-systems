using System;
using System.Linq;

namespace ComputingSystems.CombLogic.ReferenceImplementations
{
    public class And : TwoInputGate, ISingleOutputGate
    {
        public bool Output => Input1 && Input2;

        public override string ToString() => Output ? "1" : "0";
    }

    public class Demultiplexor : TwoInputGate, ITwoOutputGate
    {
        public bool Output1 => !Input2 && Input1;
        public bool Output2 => Input2 && Input1;
    }

    public class SixteenWayDemultiplexor
    {
        private readonly Demultiplexor[] _demultiplexors = Enumerable.Range(0, 16).Select(_ => new Demultiplexor()).ToArray();

        public void Fill(bool[] a, bool[] b, bool selector)
        {
            for (var i = 0; i < a.Length; i++)
            {
                _demultiplexors[i].Fill(a[i], b[i]);
            }
        }

        public bool[] Output => _multiplexors.Select(m => m.Output).ToArray();

        public static SixteenBitMultiplexor[] ArrayOf(int no) => Enumerable.Range(0, no).Select(_ => new SixteenBitMultiplexor()).ToArray();
    }

    public class Multiplexor : ThreeInputGate, ISingleOutputGate
    {
        // Input3 = control
        public bool Output => Input3 ? Input2 : Input1;
    }

    public class SixteenBitMultiplexor
    {
        private readonly Multiplexor[] _multiplexors = Enumerable.Range(0, 16).Select(_ => new Multiplexor()).ToArray();

        public void Fill(bool[] a, bool[] b, bool selector)
        {
            for (var i = 0; i < a.Length; i++)
            {
                _multiplexors[i].Fill(a[i], b[i], selector);
            }
        }

        public bool[] Output => _multiplexors.Select(m => m.Output).ToArray();

        public static SixteenBitMultiplexor[] ArrayOf(int no) => Enumerable.Range(0, no).Select(_ => new SixteenBitMultiplexor()).ToArray();
    }

    public class Nand : TwoInputGate, ISingleOutputGate
    {
        public bool Output => !(Input1 && Input2);
    }

    public class Not : SingleInputGate, ISingleOutputGate
    {
        public bool Output => !Input;
    }

    public class Or : TwoInputGate, ISingleOutputGate
    {
        public bool Output => !(!Input1 && !Input2);
    }

    public class Xor : TwoInputGate, ISingleOutputGate
    {
        public bool Output => Input1 != Input2;
    }
}
