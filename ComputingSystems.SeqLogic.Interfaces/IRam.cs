using System;
using ComputingSystems.Core;

namespace ComputingSystems.SeqLogic.Interfaces
{
    public interface IRam : IClockedComponent
    {
        IBus Address { get; }
        IPin Load { get; }
        IBus Input { get; }
        IBus Output { get; }
    }

    public interface IRam8 : IRam { }
    public interface IRam64 : IRam { }
    public interface IRam512 : IRam { }
    public interface IRam4k : IRam { }
    public interface IRam16k : IRam { }
}