namespace ComputingSystems.CombLogic.ReferenceImplementations.Tests
{
    public static class TestSetup
    {
        public static void Setup()
        {
            CombLogicReferenceImplementationsTypeModule.Bind(rebind: true);
        }
    }
}
