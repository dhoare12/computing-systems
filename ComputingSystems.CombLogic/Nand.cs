using ComputingSystems.CombLogic.Interfaces;

namespace ComputingSystems.CombLogic
{
    // This is the fundamental gate (only gate allowed to use C# boolean logic in implementation)
    public class Nand : INand
    {
        public bool Input1 { get; set; }
        public bool Input2 { get; set; }

        public bool Output => !(Input1 && Input2);

        public void Fill(bool input1, bool input2)
        {
            Input1 = input1;
            Input2 = input2;
        }
    }
}