namespace ComputingSystems.CombLogic.Interfaces
{
    public interface IOr
    {
        bool Input1 { get; set; }
        bool Input2 { get; set; }
        bool Output { get; }
        void Fill(bool input1, bool input2);
    }
}