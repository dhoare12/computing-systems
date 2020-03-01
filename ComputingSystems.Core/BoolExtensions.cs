using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputingSystems.Core
{
    public static class BoolExtensions
    {
        public static IPin ToPin(this bool value) => new ValuePin(value);
        public static IPin[] ToPins(this bool[] value) => value.Select(x => x.ToPin()).ToArray();

        public static IBus ToBus(this bool[] value) => new ValueBus(value.Length, value);
    }
}
