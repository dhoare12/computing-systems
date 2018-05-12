using System.Linq;

namespace ComputingSystems.CombLogic.ReferenceImplementations
{
    public class Demultiplexor : TwoInputGate, ITwoOutputGate
    {
        public bool Output1 => !Input2 && Input1;
        public bool Output2 => Input2 && Input1;
    }

    public class EightWayDemultiplexor
    {
        public bool Input { get; set; }
        public bool[] Selector { get; set; }

        public bool[] Outputs
        {
            // TODO: Implement this using demultiplexors
            get
            {
                var outputs = Enumerable.Range(0, 8).Select(_ => false).ToArray();
                var outputToTake = 0;
                outputToTake += Selector[2] ? 1 : 0;
                outputToTake += Selector[1] ? 2 : 0;
                outputToTake += Selector[0] ? 4 : 0;
                outputs[outputToTake] = Input;
                return outputs;
            }
        }
    }
}