namespace ComputingSystems.CombLogic.Interfaces
{
    public interface IEightWaySixteenBitMultiplexor
    {
        bool[][] Input { get; set; }
        bool[] Selector { get; set; }
        bool[] Output { get; }
    }
}