namespace ComputingSystems.CombLogic.Interfaces
{
    public interface IEightWayDemultiplexor
    {
        bool Input { get; set; }
        bool[] Selector { get; set; }
        bool[] Output { get; }
    }
}