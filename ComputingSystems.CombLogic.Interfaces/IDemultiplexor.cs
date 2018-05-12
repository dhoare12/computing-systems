namespace ComputingSystems.CombLogic.Interfaces
{
    public interface IDemultiplexor
    {
        bool Input { get; set; }
        bool Selector { get; set; }
        bool Output1 { get; }
        bool Output2 { get; }

        void Fill(bool input, bool selector);
    }
}