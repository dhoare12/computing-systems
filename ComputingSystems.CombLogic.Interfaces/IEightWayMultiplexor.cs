namespace ComputingSystems.CombLogic.Interfaces
{
    public interface IEightWayMultiplexor
    {
        bool[] Input { get; set; }
        bool[] Selector { get; set; }
        bool Output { get; }
    }
}