using System.Linq;
using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;

namespace ComputingSystems.CombLogic
{
    public class EightWayDemultiplexor : IEightWayDemultiplexor
    {
        public IPin Input { get; } = new Pin();
        public IPin[] Selector { get; } = Pin.Array(3);

        public IPin[] Output
        {
            // TODO: Implement this using demultiplexors
            get
            {
                var outputs = Enumerable.Range(0, 8).Select(_ => false).ToArray();
                var outputToTake = 0;
                outputToTake += Selector[2].Value ? 1 : 0;
                outputToTake += Selector[1].Value ? 2 : 0;
                outputToTake += Selector[0].Value ? 4 : 0;
                outputs[outputToTake] = Input.Value;
                return outputs.Select(x => new ValuePin(x)).ToArray();
            }
        }

        public void Fill(IPin input, IPin[] selector)
        {
            Input.AttachInput(input);
            Selector.AttachInputs(selector);
        }
    }
}