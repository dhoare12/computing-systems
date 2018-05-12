namespace ComputingSystems.CombLogic.ReferenceImplementations.Tests
{
    public static class TestSetup
    {
        public static void Setup()
        {
            CombLogicTypeModule.Bind(rebind: true);
        }
    }
}
