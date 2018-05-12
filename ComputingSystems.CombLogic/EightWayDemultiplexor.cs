using System.Linq;
using ComputingSystems.CombLogic.Interfaces;

namespace ComputingSystems.CombLogic
{
    public class EightWayDemultiplexor : IEightWayDemultiplexor
    {
        public bool Input { get; set; }
        public bool[] Selector { get; set; }

        public bool[] Output
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