using System;
using System.Linq;

namespace ComputingSystems.CombLogic.ReferenceImplementations
{
    public class And : TwoInputGate, ISingleOutputGate
    {
        public bool Output => Input1 && Input2;

        public override string ToString() => Output ? "1" : "0";
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
