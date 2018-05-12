using ComputingSystems.Core;

namespace ComputingSystems.CombLogic.ReferenceImplementations
{
    public static class CombLogicReferenceImplementationsTypeModule
    {
        public static void Bind()
        {
            TypeProvider.Bind(() => new Nand());
            TypeProvider.Bind(() => new Not());
            TypeProvider.Bind(() => new Xor());

            TypeProvider.Bind(() => new And());
            TypeProvider.Bind(() => new Or());

            TypeProvider.Bind(() => new Multiplexor());
            TypeProvider.Bind(() => new EightWayMultiplexor());
            TypeProvider.Bind(() => new EightWaySixteenBitMultiplexor());

            TypeProvider.Bind(() => new Demultiplexor());
            TypeProvider.Bind(() => new EightWayDemultiplexor());
        }
    }
}