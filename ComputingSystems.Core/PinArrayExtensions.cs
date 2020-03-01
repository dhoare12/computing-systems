using System;
using System.Linq;

namespace ComputingSystems.Core
{
    public static class PinArrayExtensions
    {
        public static void AttachInputs(this IPin[] pinArray, IPin[] inputs)
        {
            if (pinArray.Length != inputs.Length)
            {
                throw new Exception($"Pin array length mismatch - plugging {inputs.Length} into {pinArray.Length}");
            }

            for (var i = 0; i < pinArray.Length; i++)
            {
                pinArray[i].AttachInput(inputs[i]);
            }
        }

        public static bool[] Values(this IPin[] pinArray) => pinArray.Select(x => x.Value).ToArray();
    }
}
