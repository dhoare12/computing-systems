namespace ComputingSystems.CombLogic
{
    public abstract class SingleInputGate
    {
        public void Fill(bool input)
        {
            Input = input;
        }
        public bool Input { get; private set; }
    }

    public abstract class TwoInputGate
    {
        public void Fill(bool input1, bool input2)
        {
            Input1 = input1;
            Input2 = input2;
        }

        public bool Input1 { get; private set; }
        public bool Input2 { get; private set; }
    }

    public abstract class ThreeInputGate
    {
        public void Fill(bool input1, bool input2, bool input3)
        {
            Input1 = input1;
            Input2 = input2;
            Input3 = input3;
        }
        public bool Input1 { get; private set; }
        public bool Input2 { get; private set; }
        public bool Input3 { get; private set; }
    }

    public interface ISingleOutputGate
    {
        bool Output { get; }
    }

    public interface ITwoOutputGate
    {
        bool Output1 { get; }
        bool Output2 { get; }
    }
}