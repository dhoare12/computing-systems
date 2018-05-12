using System;
using ComputingSystems.Core;
using ComputingSystems.SeqLogic.Interfaces;

namespace ComputingSystems.SeqLogic
{
    public static class SeqLogicTypeModule
    {
        public static void Bind(bool rebind = false)
        {
            Bind<IRam8>(() => new Ram8(), rebind);
            Bind<IRam64>(() => new Ram64(), rebind);
            Bind<IRam512>(() => new Ram512(), rebind);
            Bind<IRam4k>(() => new Ram4k(), rebind);
            Bind<IRam16k>(() => new Ram16k(), rebind);
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
