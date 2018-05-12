using System;

namespace ComputingSystems.SeqLogic.Interfaces
{
    public interface IRam : IClockedComponent
    {
        bool[] Address { get; set; }
        bool Load { get; set; }
        bool[] Input { get; set; }
        bool[] Output { get; }
    }

    public interface IRam8 : IRam { }
    public interface IRam64 : IRam { }
    public interface IRam512 : IRam { }
    public interface IRam4k : IRam { }
    public interface IRam16k : IRam { }
}