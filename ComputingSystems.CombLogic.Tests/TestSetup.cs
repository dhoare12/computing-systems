namespace ComputingSystems.CombLogic.Tests
{
    public static class TestSetup
    {
        public static void Setup()
        {
            CombLogicTypeModule.Bind(rebind: true);
        }
    }
}
