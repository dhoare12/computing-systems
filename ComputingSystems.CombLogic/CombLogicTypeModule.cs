using System;
using System.Collections.Generic;
using System.Text;
using ComputingSystems.CombLogic.Interfaces;
using ComputingSystems.Core;

namespace ComputingSystems.CombLogic
{
    public static class CombLogicTypeModule
    {
        public static void Bind(bool rebind = false)
        {
            Bind<INand>(() => new Nand(), rebind);
            Bind<INot>(() => new Not(), rebind);
            Bind<IXor>(() => new Xor(), rebind);

            Bind<IAnd>(() => new And(), rebind);
            Bind<IOr>(() => new Or(), rebind);

            Bind<IMultiplexor>(() => new Multiplexor(), rebind);
            Bind<IEightWayMultiplexor>(() => new EightWayMultiplexor(), rebind);
            Bind<IEightWaySixteenBitMultiplexor>(() => new EightWaySixteenBitMultiplexor(), rebind);

            Bind<IDemultiplexor>(() => new Demultiplexor(), rebind);
            Bind<IEightWayDemultiplexor>(() => new EightWayDemultiplexor(), rebind);
        }

        private static void Bind<T>(Func<T> func, bool rebind)
        {
            if (rebind)
            {
                TypeProvider.ReBind<T>(func);
            }
            else
            {
                TypeProvider.Bind<T>(func);
            }
        }
    }
}
