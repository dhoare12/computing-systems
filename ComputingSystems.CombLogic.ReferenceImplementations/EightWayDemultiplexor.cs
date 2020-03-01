using System.Linq;
using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;

namespace ComputingSystems.CombLogic.ReferenceImplementations
{
    public class EightWayDemultiplexor : IEightWayDemultiplexor
    {
        public EightWayDemultiplexor()
        {
            Output = Enumerable.Range(0, 8).Select(x => new ValuePin(() => GetResults()[x])).ToArray();
        }
        public IPin Input { get; } = new Pin();
        public IPin[] Selector { get; } = Enumerable.Range(0, 3).Select(_ => new Pin()).ToArray();

        public IPin[] Output { get; }
        public void Fill(IPin input, IPin[] selector)
        {
            Input.AttachInput(input);
            for (var i = 0; i < 3; i++)
            {
                Selector[i].AttachInput(selector[i]);
            }
        }

        private bool[] GetResults()
        {
            var outputs = Enumerable.Range(0, 8).Select(_ => false).ToArray();
            var outputToTake = 0;
            outputToTake += Selector[2].Value ? 1 : 0;
            outputToTake += Selector[1].Value ? 2 : 0;
            outputToTake += Selector[0].Value ? 4 : 0;
            outputs[outputToTake] = Input.Value;
            return outputs;
        }
    }
}